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

            query = query.Filtering(search);

            query = QueryExtensions.QueryChain(query);

            return query;
        }

        public override Model.MusicShop GetById(int id)
        {
            var entity = context.MusicShops.QueryChain().CompareId(id);

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

            var result = QueryExtensions.QueryChain(context.MusicShops).CompareId(entity.Id);

            return entity != null ? mapper.Map<Model.MusicShop>(entity) : null;
        }

        public override Model.MusicShop Update(int id, MusicShopUpsertRequest request)
        {
            var entity = context.MusicShops.QueryChain().CompareId(id);

            entity.Naziv = request.Naziv;

            if (!string.IsNullOrEmpty(request.Adresa))
            {
                AddressBuilder.Update(context, entity.Adresa, request.Adresa);
                context.SaveChanges();
            }

            context.SaveChanges();

            var result = QueryExtensions.QueryChain(context.MusicShops).CompareId(entity.Id);

            return entity != null ? mapper.Map<Model.MusicShop>(entity) : null;
        }
    }
}
