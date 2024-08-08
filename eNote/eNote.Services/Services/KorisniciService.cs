using eNote.Model;
using eNote.Model.Requests.Korisnik;
using eNote.Model.SearchObjects;
using eNote.Services.Database;
using eNote.Services.Helpers;
using eNote.Services.Interfaces;
using Mapster;
using MapsterMapper;
using Microsoft.EntityFrameworkCore;

namespace eNote.Services.Services
{
    public class KorisniciService(ENoteContext context, IMapper mapper)
        : CRUDService<Model.Korisnik, KorisnikSearchObject, KorisnikInsertRequest, KorisnikUpdateRequest, Database.Korisnik>(context, mapper), IKorisniciService
    {
        public override async Task<PagedResult<Model.Korisnik>> GetPaged(KorisnikSearchObject search)
        {
            var query = AddFilter(search, context.Korisnici.AsQueryable());

            if(!string.IsNullOrEmpty(search.Uloga))
            {
                query = QueryBuilder.ApplyRole(query, search.Uloga);
            }

            var totalCount = await query.CountAsync();

            query = QueryBuilder.ApplyPaging(query, search.Page, search.PageSize);

            var list = await query.ToListAsync();

            var resultList = mapper.Map<List<Model.Korisnik>>(list);

            return new PagedResult<Model.Korisnik>
            {
                ResultList = resultList,
                Count = totalCount,
                CurrentPage = search.Page ?? 1
            };
        }       

        public override IQueryable<Database.Korisnik> AddFilter(KorisnikSearchObject search, IQueryable<Database.Korisnik> query)
        {
            query = base.AddFilter(search, query);

            query = QueryBuilder.ApplyFilters(query, builder =>
            {
                builder.Add("Ime", search.Ime)
                       .Add("Prezime", search.Prezime)
                       .Add("KorisnickoIme", search.KorisnickoIme)
                       .Add("Naziv", search.Naziv)
                       .AddNavigation<Uloge>("Uloga", "Naziv", search.Uloga)
                       .AddNavigation<Adresa>("Adresa", "Grad", search.Grad);
            });

            query = QueryBuilder.ApplyChaining(query);

            return query;
        }

        public override async Task<Model.Korisnik> GetById(int id)
        {
            var entity = await QueryBuilder.ApplyChaining(context.Korisnici).FirstOrDefaultAsync(x => x.Id == id);

            if (entity == null)
            {
                return null;
            }

            return mapper.Map<Model.Korisnik>(entity);                           
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
