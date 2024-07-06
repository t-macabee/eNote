using eNote.Model.Pagination;
using eNote.Model.Requests.Instrument;
using eNote.Model.Requests.Korisnik;
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
        : CRUDService<Model.MusicShop, MusicShopSearchObject, MusicShopUpsertRequest, MusicShopUpsertRequest, Database.MusicShop>(context, mapper), IMusicShopService
    {
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

        public override Model.MusicShop GetById(int id)
        { 
            var entity = QueryBuilder.ApplyChaining(Context.MusicShops).FirstOrDefault(x => x.Id == id);

            return entity == null ? throw new KeyNotFoundException("ID nije pronadjen.") : Mapper.Map<Model.MusicShop>(entity);
        }

        public override Model.MusicShop Insert(MusicShopUpsertRequest request)
        {
            var adresa = AddressBuilder.Create(Context, request.Adresa);

            var entity = new MusicShop
            {
                Naziv = request.Naziv,
                Adresa = adresa,
            };

            Context.MusicShops.Add(entity);
            Context.SaveChanges();

            var result = QueryBuilder.ApplyChaining(Context.MusicShops).FirstOrDefault(x => x.Id == entity.Id);

            return entity == null ? throw new KeyNotFoundException("ID nije pronadjen.") : Mapper.Map<Model.MusicShop>(entity);
        }

        public override Model.MusicShop Update(int id, MusicShopUpsertRequest request)
        {
            ArgumentNullException.ThrowIfNull(request);

            var entity = QueryBuilder.ApplyChaining(Context.MusicShops).FirstOrDefault(x => x.Id == id)
                ?? throw new KeyNotFoundException("ID nije pronadjen.");

            if (!string.IsNullOrWhiteSpace(request.Naziv))
            {
                entity.Naziv = request.Naziv;
            }

            if (!string.IsNullOrWhiteSpace(request.Adresa))
            {                
                entity.Adresa ??= new Adresa();

                AddressBuilder.Update(entity.Adresa, request.Adresa);
            }

            BeforeUpdate(request, entity);
            Context.SaveChanges();

            return Mapper.Map<Model.MusicShop>(entity);
        }
    }
}
