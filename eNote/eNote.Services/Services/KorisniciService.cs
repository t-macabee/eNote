using eNote.Model.Enums;
using eNote.Model.Requests.Korisnik;
using eNote.Model.SearchObjects;
using eNote.Services.Database;
using eNote.Services.Helpers;
using eNote.Services.Interfaces;
using MapsterMapper;
using Microsoft.EntityFrameworkCore;

namespace eNote.Services.Services
{
    public class KorisniciService(ENoteContext context, IMapper mapper)
        : CRUDService<Model.Korisnik, KorisnikSearchObject, KorisnikInsertRequest, KorisnikUpdateRequest, Database.Korisnik>(context, mapper), IKorisniciService
    {
      
        public override IQueryable<Korisnik> AddFilter(KorisnikSearchObject search, IQueryable<Korisnik> query)
        {
            query = base.AddFilter(search, query).Include(x => x.Adresa)
                .Where(x =>
                    (string.IsNullOrEmpty(search.Ime) || x.Ime.StartsWith(search.Ime)) &&
                    (string.IsNullOrEmpty(search.Prezime) || x.Prezime.StartsWith(search.Prezime)) &&
                    (string.IsNullOrEmpty(search.KorisnickoIme) || x.KorisnickoIme == search.KorisnickoIme) &&
                    (string.IsNullOrEmpty(search.Grad) || x.Adresa.Grad.StartsWith(search.Grad)) &&
                     (!search.Uloga.HasValue || x.Uloga == search.Uloga.Value) && (!search.Uloga.HasValue || x.Uloga != Uloge.MusicShop)
                );

            return query;
        }

        public override async Task<Model.Korisnik> GetById(int id)
        {
            var entity = await context.Korisnici.Include(x => x.Adresa).FirstOrDefaultAsync(x => x.Id == id);

            return entity == null ? null : mapper.Map<Model.Korisnik>(entity);
        }

        public override async Task BeforeInsert(KorisnikInsertRequest request, Database.Korisnik entity)
        {
            if (request == null)
            {
                throw new ArgumentNullException(nameof(request), "Unos ne može biti null.");
            }

            var existingUsername = await context.Korisnici.FirstOrDefaultAsync(x => x.KorisnickoIme == request.KorisnickoIme);

            if (existingUsername != null)
            {
                throw new Exception("Korisničko ime je u upotrebi.");
            }

            var existingEmail = await context.Korisnici.FirstOrDefaultAsync(x => x.Email == request.Email);

            if (existingEmail != null)
            {
                throw new Exception("E-mail je u upotrebi.");
            }

            if (request.Lozinka != request.LozinkaPotvrda)
            {
                throw new Exception("Lozinka i LozinkaPotvrda moraju biti iste!");
            }

            var validRoles = Enum.GetValues<Uloge>().Where(role => role != Uloge.MusicShop).ToList();
            if (!validRoles.Contains(request.Uloga))
            {
                throw new Exception("Nevažeća uloga.");
            }

            entity.Uloga = request.Uloga;

            var adresa = await AddressBuilder.GetOrCreateAdresa(context, request);
            entity.AdresaId = adresa.Id;
            entity.Adresa = adresa;

            entity.LozinkaSalt = PasswordBuilder.GenerateSalt();
            entity.LozinkaHash = PasswordBuilder.GenerateHash(entity.LozinkaSalt, request.Lozinka);

            await base.BeforeInsert(request, entity);
        }

        public override async Task BeforeUpdate(KorisnikUpdateRequest request, Database.Korisnik entity)
        {
            entity = await context.Korisnici.Include(x => x.Adresa).FirstOrDefaultAsync(x => x.Id == entity.Id);

            if (entity == null)
            {
                throw new Exception("Korisnik ne postoji.");
            }

            if (request.Lozinka != null)
            {
                if (request.Lozinka != request.LozinkaPotvrda)
                {
                    throw new Exception("Lozinka i lozinka potvrda moraju biti iste!");
                }

                entity.LozinkaSalt = PasswordBuilder.GenerateSalt();
                entity.LozinkaHash = PasswordBuilder.GenerateHash(entity.LozinkaSalt, request.Lozinka);
            }

            await base.BeforeUpdate(request, entity);
        }

        public async Task<List<Model.DTOs.Adresa>> GetAddresses()
        {
            var result = await context.Adresa.ToListAsync();
            return mapper.Map<List<Model.DTOs.Adresa>>(result);
        }
    }
}
