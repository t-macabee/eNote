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

            if (!string.IsNullOrWhiteSpace(search?.Naziv))
            {
                query = query.Where(x => x.Naziv.Contains(search.Naziv));
            }

            if (!string.IsNullOrWhiteSpace(search?.Adresa))
            {
                query = query.Include(x => x.Adresa).Where(x => x.Adresa.Grad.Contains(search.Adresa) 
                    || x.Adresa.Ulica.Contains(search.Adresa) 
                    || x.Adresa.Broj.Contains(search.Adresa));                
            }

            query = QueryChain.IncludeMusicShop(query);

            return query;
        }

        public override Model.MusicShop GetById(int id)
        {
            var entity = QueryChain.IncludeMusicShop(context.MusicShops).FirstOrDefault(x => x.Id == id);

            return entity != null ? mapper.Map<Model.MusicShop>(entity) : null;
        }

        public override Model.MusicShop Insert(MusicShopUpsertRequest request)
        {
            var adresa = AddressUtils.Create(context, request.Adresa);

            var entity = new MusicShop
            {
                Naziv = request.Naziv,
                Adresa = adresa,
            };

            context.MusicShops.Add(entity);
            context.SaveChanges();

            var result = QueryChain.IncludeMusicShop(context.MusicShops)
                .FirstOrDefault(x => x.Id == entity.Id);

            return entity != null ? mapper.Map<Model.MusicShop>(entity) : null;
        }

        public override Model.MusicShop Update(int id, MusicShopUpsertRequest request)
        {
            var entity = QueryChain.IncludeMusicShop(context.MusicShops).FirstOrDefault(x => x.Id == id);

            entity.Naziv = request.Naziv;

            if (!string.IsNullOrEmpty(request.Adresa))
            {
                AddressUtils.Update(context, entity.Adresa, request.Adresa);
                context.SaveChanges();
            }

            context.SaveChanges();

            var result = QueryChain.IncludeMusicShop(context.MusicShops)
                .FirstOrDefault(x => x.Id == entity.Id);

            return entity != null ? mapper.Map<Model.MusicShop>(entity) : null;
        }
    }
}
