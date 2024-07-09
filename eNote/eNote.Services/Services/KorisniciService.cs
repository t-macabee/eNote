using eNote.Model;
using eNote.Model.Requests.Korisnik;
using eNote.Model.SearchObjects;
using eNote.Services.Database;
using eNote.Services.Helpers;
using eNote.Services.Interfaces;
using MapsterMapper;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Conventions;
using Microsoft.Extensions.Logging;

namespace eNote.Services.Services
{
    public class KorisniciService : CRUDService<Model.Korisnik, KorisnikSearchObject, KorisnikInsertRequest, KorisnikUpdateRequest, Database.Korisnik>, IKorisniciService
    {
        public KorisniciService(ENoteContext context, IMapper mapper) : base(context, mapper)
        {
        }

        public override IQueryable<Database.Korisnik> AddFilter(KorisnikSearchObject search, IQueryable<Database.Korisnik> query)
        {
            query = base.AddFilter(search, query);

            query = query.ApplyFilters(
            [
               x => search?.Ime != null ? x.Where(k => k.Ime.StartsWith(search.Ime)) : x,
               x => search?.Prezime != null ? x.Where(k => k.Prezime.StartsWith(search.Prezime)) : x,
               x => search?.KorisnickoIme != null ? x.Where(k => k.KorisnickoIme.StartsWith(search.KorisnickoIme)) : x,
               x => search?.Grad != null ? x.Include(k => k.Adresa).Where(k => k.Adresa != null && k.Adresa.Grad.StartsWith(search.Grad)) : x
            ]);

            int count = query.Count();

            query = QueryBuilder.ApplyPaging(query, search?.Page, search?.PageSize);

            query = QueryBuilder.ApplyChaining(query);

            return query;
        }

        public override async Task<Model.Korisnik> GetById(int id)
        {
            var entity = await QueryBuilder.ApplyChaining(context.Korisnici).FirstOrDefaultAsync(x => x.Id == id);

            return entity == null ? throw new KeyNotFoundException("ID nije pronadjen.") : mapper.Map<Model.Korisnik>(entity);
        }

        public override async Task<Model.Korisnik> Insert(KorisnikInsertRequest request)
        {
            var insertedEntity = await base.Insert(request);

            var entity = await QueryBuilder.ApplyChaining(context.Korisnici).FirstOrDefaultAsync(x => x.Id == insertedEntity.Id);

            return entity == null ? throw new Exception("Korisnik nije pronadjen.") : mapper.Map<Model.Korisnik>(entity);
        }

        public override async Task<Model.Korisnik> Update(int id, KorisnikUpdateRequest request)
        {
            await base.Update(id, request);

            var entity = await QueryBuilder.ApplyChaining(context.Korisnici).FirstOrDefaultAsync(x => x.Id == id);

            return entity == null ? throw new Exception("Korisnik nije pronadjen.") : mapper.Map<Model.Korisnik>(entity);
        }

        public async Task<Model.Korisnik> Login(string korisnickoIme, string lozinka)
        {
            var entity = await QueryBuilder.ApplyChaining(context.Korisnici).FirstOrDefaultAsync(x => x.KorisnickoIme == korisnickoIme) ?? throw new Exception("Nevažeće korisničko ime.");

            return !PasswordBuilder.VerifyPassword(entity.LozinkaSalt, lozinka, entity.LozinkaHash) ? throw new Exception("Nevažeća lozinka.") : mapper.Map<Model.Korisnik>(entity);
        }

        public override async Task BeforeInsert(KorisnikInsertRequest request, Database.Korisnik entity)
        {                        
            var existingUsername = context.Korisnici.FirstOrDefault(x => x.KorisnickoIme == request.KorisnickoIme);

            if (existingUsername != null) 
            {
                throw new Exception("Korisničko ime već postoji. Molimo odaberite drugo korisničko ime.");
            }

            var existingEmail = context.Korisnici.FirstOrDefault(x => x.Email == request.Email);

            if (existingEmail != null)
            {
                throw new Exception("Email već postoji. Molimo odaberite drugu email adresu.");
            }

            if (request.Lozinka != request.LozinkaPotvrda)
            {
                throw new Exception("Lozinka i LozinkaPotvrda moraju biti iste!");
            }

            entity.UlogaId = request.UlogaId;

            entity.AdresaId = request.AdresaId ?? 0;

            entity.LozinkaSalt = PasswordBuilder.GenerateSalt();

            entity.LozinkaHash = PasswordBuilder.GenerateHash(entity.LozinkaSalt, request.Lozinka);

            await base.BeforeInsert(request, entity);
        }

        public override async Task BeforeUpdate(KorisnikUpdateRequest request, Database.Korisnik entity)
        {
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
    }
}
