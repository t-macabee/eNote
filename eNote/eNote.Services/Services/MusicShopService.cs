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
    public class MusicShopService : CRUDService<Model.MusicShop, MusicShopSearchObject, MusicShopUpsertRequest, MusicShopUpsertRequest, Database.MusicShop>, IMusicShopService
    {
        public MusicShopService(eNoteContext context, IMapper mapper) : base(context, mapper)
        {
        }

        public override IQueryable<MusicShop> AddFilter(MusicShopSearchObject search, IQueryable<MusicShop> query)
        {
            query = base.AddFilter(search, query);

            query = query.ApplyFilters(new List<Func<IQueryable<MusicShop>, IQueryable<MusicShop>>>
            {
                 x => !string.IsNullOrWhiteSpace(search?.Naziv) ? x.Where(k => k.Naziv.Contains(search.Naziv)) : x,
                 x => !string.IsNullOrWhiteSpace(search?.Adresa) ? x.Include(k => k.Adresa).Where(k => k.Adresa.Grad.Contains(search.Adresa)
                                                             || k.Adresa.Ulica.Contains(search.Adresa)
                                                             || k.Adresa.Broj.Contains(search.Adresa)) : x
            });                    

            query = QueryBuilder.ApplyPaging(query, search?.Page, search?.PageSize);

            query = QueryBuilder.ApplyChaining(query);

            return query;
        }

        public override Model.MusicShop GetById(int id)
        { 
            var entity = QueryBuilder.ApplyChaining(context.MusicShops).FirstOrDefault(x => x.Id == id);

            return entity != null ? mapper.Map<Model.MusicShop>(entity) : null;
        }

        public override Model.MusicShop Insert(MusicShopUpsertRequest request)
        {
            var adresa = AddressBuilder.Create(context, request.Adresa);

            var entity = new MusicShop
            {
                Naziv = request.Naziv,
                Adresa = adresa,
            };

            context.MusicShops.Add(entity);
            context.SaveChanges();

            var result = QueryBuilder.ApplyChaining(context.MusicShops).FirstOrDefault(x => x.Id == entity.Id);

            return entity != null ? mapper.Map<Model.MusicShop>(entity) : null;
        }

        public override Model.MusicShop Update(int id, MusicShopUpsertRequest request)
        {
            var entity = QueryBuilder.ApplyChaining(context.MusicShops).FirstOrDefault(x => x.Id == id);

            entity.Naziv = request.Naziv;

            if (!string.IsNullOrEmpty(request.Adresa))
            {
                AddressBuilder.Update(context, entity.Adresa, request.Adresa);
                context.SaveChanges();
            }

            context.SaveChanges();

            var result = QueryBuilder.ApplyChaining(context.MusicShops).FirstOrDefault(x => x.Id == entity.Id);

            return entity != null ? mapper.Map<Model.MusicShop>(entity) : null;
        }
    }
}
