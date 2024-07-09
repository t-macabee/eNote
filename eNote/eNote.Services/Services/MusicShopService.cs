using eNote.Model.Requests.MusicShop;
using eNote.Model.SearchObjects;
using eNote.Services.Database;
using eNote.Services.Helpers;
using eNote.Services.Interfaces;
using MapsterMapper;
using Microsoft.EntityFrameworkCore;

namespace eNote.Services.Services
{
    public class MusicShopService : CRUDService<Model.MusicShop, MusicShopSearchObject, MusicShopUpsertRequest, MusicShopUpsertRequest, Database.MusicShop>, IMusicShopService
    {
        public MusicShopService(ENoteContext context, IMapper mapper) : base(context, mapper)
        {
        }

        public override IQueryable<MusicShop> AddFilter(MusicShopSearchObject search, IQueryable<MusicShop> query)
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

        public override async Task<Model.MusicShop> Insert(MusicShopUpsertRequest request)
        {
            var adresa = await AddressBuilder.Create(context, request.Adresa);

            var entity = new MusicShop
            {
                Naziv = request.Naziv,
                Adresa = adresa,
            };

            await context.MusicShops.AddAsync(entity);
            await context.SaveChangesAsync();

            var result = QueryBuilder.ApplyChaining(context.MusicShops).FirstOrDefault(x => x.Id == entity.Id);

            return entity == null ? throw new KeyNotFoundException("ID nije pronadjen.") : mapper.Map<Model.MusicShop>(entity);
        }

        public override async Task<Model.MusicShop> Update(int id, MusicShopUpsertRequest request)
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
