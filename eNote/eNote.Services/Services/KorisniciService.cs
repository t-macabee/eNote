using eNote.Model.Pagination;
using eNote.Model.Requests.Korisnik;
using eNote.Model.SearchObjects;
using eNote.Services.Database;
using eNote.Services.Interfaces;
using Mapster;
using MapsterMapper;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Conventions;
using System.Security.Cryptography;
using System.Text;
using System.Xml.Linq;

namespace eNote.Services.Services
{
    public class KorisniciService : IKorisniciService
    {
        public eNoteContext context { get; set; }
        public IMapper mapper { get; set; }

        public KorisniciService(eNoteContext context, IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }

        public PagedResult<Model.Korisnik> GetAll(KorisnikSearchObject searchObject)
        {        
            var query = context.Korisnici.Include(x => x.Uloga).AsQueryable();

            if(!string.IsNullOrWhiteSpace(searchObject?.ImeGTE))
            {
                query = query.Where(x => x.Ime.StartsWith(searchObject.ImeGTE));
            }

            if (!string.IsNullOrWhiteSpace(searchObject?.PrezimeGTE))
            {
                query = query.Where(x => x.Prezime.StartsWith(searchObject.PrezimeGTE));
            }

            if (!string.IsNullOrWhiteSpace(searchObject?.KorisnickoIme))
            {
                query = query.Where(x => x.KorisnickoIme == searchObject.KorisnickoIme);
            }            

            int count = query.Count();

            if(searchObject?.Page.HasValue == true && searchObject.PageSize.HasValue == true)
            {
                query = query.Skip(searchObject.Page.Value * searchObject.PageSize.Value)
                    .Take(searchObject.PageSize.Value);
            }            

            var list = query.ToList();

            var resultList = mapper.Map<List<Model.Korisnik>>(list);

            return new PagedResult<Model.Korisnik>
            {
                ResultList = resultList,
                Count = count
            };
        }

        public Model.Korisnik GetById(int id)
        {
            return context.Korisnici
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
            mapper.Map(request, entity);

            entity.UlogaId = request.UlogaId;
            entity.LozinkaSalt = GenerateSalt();
            entity.LozinkaHash = GenerateHash(entity.LozinkaSalt, request.Lozinka);

            context.Add(entity);
            context.SaveChanges();

            context.Entry(entity).Reference(x => x.Uloga).Load();

            return entity.Adapt<Model.Korisnik>();
        }

        public Model.Korisnik Update(int id, KorisnikUpdateRequest request)
        {
            var entity = context.Korisnici.Find(id);

            mapper.Map(request, entity);

            if(request.Lozinka != null)
            {
                if (request.Lozinka != request.LozinkaPotvrda)
                {
                    throw new Exception("Lozinka i lozinka potvrda moraju biti iste!");
                }
                entity.LozinkaSalt = GenerateSalt();
                entity.LozinkaHash = GenerateHash(entity.LozinkaSalt, request.Lozinka);
            }            

            context.SaveChanges();

            context.Entry(entity).Reference(x => x.Uloga).Load();

            return mapper.Map<Model.Korisnik>(entity);
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
