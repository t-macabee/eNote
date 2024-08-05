using eNote.Model;
using eNote.Model.Requests.MusicShop;
using eNote.Model.SearchObjects;
using eNote.Services.Database;
using eNote.Services.Helpers;
using eNote.Services.Interfaces;
using MapsterMapper;
using Microsoft.EntityFrameworkCore;

namespace eNote.Services.Services
{
    public class MusicShopService(ENoteContext context, IMapper mapper) 
        : CRUDService<Model.MusicShop, MusicShopSearchObject, MusicShopInsertRequest, MusicShopUpdateRequest, Database.MusicShop>(context, mapper), IMusicShopService
    {
        public override IQueryable<Database.MusicShop> AddFilter(MusicShopSearchObject search, IQueryable<Database.MusicShop> query)
        {
            query = base.AddFilter(search, query);

            query = query.ApplyFilters(
            [
                x => !string.IsNullOrWhiteSpace(search?.Naziv) ? x.Where(k => k.Naziv.Contains(search.Naziv)) : x,
                x => !string.IsNullOrWhiteSpace(search?.Adresa) ? x.Include(k => k.Adresa)
                    .Where(k => k.Adresa != null && (k.Adresa.Grad.Contains(search.Adresa) ||
                                                    k.Adresa.Ulica.Contains(search.Adresa) || 
                                                    k.Adresa.Broj.Contains(search.Adresa))) : x
            ]);

            query = QueryBuilder.ApplyPaging(query, search?.Page, search?.PageSize);

            query = QueryBuilder.ApplyChaining(query);

            return query;
        }
        
        public override async Task<Model.MusicShop> GetById(int id)
        { 
            var entity = await QueryBuilder.ApplyChaining(context.MusicShops).FirstOrDefaultAsync(x => x.Id == id);

            return entity == null ?
                throw new KeyNotFoundException("ID nije pronadjen.") 
                : mapper.Map<Model.MusicShop>(entity);
        }

        public override Task<Model.MusicShop> Insert(MusicShopInsertRequest request)
        {
            return base.Insert(request);
        }

        public async Task<Model.MusicShop> Login(string username, string password)
        {
            var entity = await QueryBuilder.ApplyChaining(context.MusicShops).FirstOrDefaultAsync(x => x.KorisnickoIme == username);

            if (entity == null || !PasswordBuilder.VerifyPassword(entity.LozinkaSalt, password, entity.LozinkaHash))
            {
                throw new Exception("Invalid username or password.");
            }

            return mapper.Map<Model.MusicShop>(entity);
        }

        /*
         *  public async Task<Model.Korisnik> Login(string username, string password)
        {
            var entity = await QueryBuilder.ApplyChaining(context.Korisnici).FirstOrDefaultAsync(x => x.KorisnickoIme == username);

            if (entity == null || !PasswordBuilder.VerifyPassword(entity.LozinkaSalt, password, entity.LozinkaHash))
            {
                throw new Exception("Invalid username or password.");
            }

            return mapper.Map<Model.Korisnik>(entity);
        }
         */

        public override async Task<Model.MusicShop> Update(int id, MusicShopUpdateRequest request)
        {
            ArgumentNullException.ThrowIfNull(request);

            var entity = QueryBuilder.ApplyChaining(context.MusicShops).FirstOrDefault(x => x.Id == id)
                ?? throw new KeyNotFoundException("ID nije pronadjen.");

            if (!string.IsNullOrWhiteSpace(request.Naziv))
            {
                entity.Naziv = request.Naziv;
            }

            if (!string.IsNullOrWhiteSpace(request.Adresa))
            {                
                entity.Adresa ??= new Adresa();

                await AddressBuilder.Update(context, entity.Adresa, request.Adresa);
            }

            await BeforeUpdate(request, entity);

            await context.SaveChangesAsync();

            return mapper.Map<Model.MusicShop>(entity);
        }
    }
}
