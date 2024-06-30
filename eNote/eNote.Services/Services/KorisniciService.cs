using eNote.Model.Requests.Korisnik;
using eNote.Services.Database;
using eNote.Services.Interfaces;
using Mapster;
using MapsterMapper;
using Microsoft.EntityFrameworkCore;
using System.Security.Cryptography;
using System.Text;

namespace eNote.Services.Services
{
    public class KorisniciService : IKorisniciService
    {
        public DataContext _context { get; set; }
        public IMapper _mapper { get; set; }

        public KorisniciService(DataContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public List<Model.Korisnik> GetAll()
        {
            return _context.Korisnici
                .Include(x => x.Uloga)
                .ProjectToType<Model.Korisnik>()
                .ToList();
        }

        public Model.Korisnik GetById(int id)
        {
            return _context.Korisnici
                .Include(x => x.Uloga)
                .Where(x => x.Id == id)
                .ProjectToType<Model.Korisnik>()
                .FirstOrDefault();
        }


        public Model.Korisnik Insert(KorisnikInsertRequest request)
        {
            if(request.Lozinka != request.LozinkaPotvrda)
            {
                throw new Exception("Lozinka i lozinka potvrda moraju biti iste!");
            }

            var entity = new Korisnik();
            _mapper.Map(request, entity);

            entity.UlogaId = request.UlogaId;
            entity.LozinkaSalt = GenerateSalt();
            entity.LozinkaHash = GenerateHash(entity.LozinkaSalt, request.Lozinka);

            _context.Add(entity);
            _context.SaveChanges();

            _context.Entry(entity).Reference(x => x.Uloga).Load();

            return entity.Adapt<Model.Korisnik>();
        }

        public Model.Korisnik Update(int id, KorisnikUpdateRequest request)
        {
            var entity = _context.Korisnici.Find(id);

            _mapper.Map(request, entity);

            if(request.Lozinka != null)
            {
                if (request.Lozinka != request.LozinkaPotvrda)
                {
                    throw new Exception("Lozinka i lozinka potvrda moraju biti iste!");
                }
                entity.LozinkaSalt = GenerateSalt();
                entity.LozinkaHash = GenerateHash(entity.LozinkaSalt, request.Lozinka);
            }            

            _context.SaveChanges();

            _context.Entry(entity).Reference(x => x.Uloga).Load();

            return _mapper.Map<Model.Korisnik>(entity);
        }

        public static string GenerateSalt()
        {             
            var byteArray = RNGCryptoServiceProvider.GetBytes(16);

            return Convert.ToBase64String(byteArray);
        }

        public static string GenerateHash(string salt, string password)
        {
            byte[] src = Convert.FromBase64String(salt);
            byte[] bytes = Encoding.Unicode.GetBytes(password);
            byte[] dst = new byte[src.Length + bytes.Length];

            System.Buffer.BlockCopy(src, 0, dst, 0, src.Length);
            System.Buffer.BlockCopy(bytes, 0, dst, src.Length, bytes.Length);

            HashAlgorithm algorithm = HashAlgorithm.Create("SHA1");
            byte[] inArray = algorithm.ComputeHash(dst);

            return Convert.ToBase64String(inArray);
        }

       
    }
}
