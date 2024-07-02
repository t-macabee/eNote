using eNote.Model.Pagination;
using eNote.Model.Requests.Instrument;
using eNote.Model.Requests.Korisnik;
using eNote.Model.Requests.MusicShop;
using eNote.Model.SearchObjects;
using eNote.Services.Database;
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

            if (!string.IsNullOrWhiteSpace(search?.NazivGTE))
            {
                query = query.Where(x => x.Naziv.Contains(search.NazivGTE));
            }

            if (!string.IsNullOrWhiteSpace(search?.LokacijaGTE))
            {
                query = query.Where(x => x.Adresa != null && $"{x.Adresa.Ulica} {x.Adresa.Broj}, {x.Adresa.Grad}".Contains(search.LokacijaGTE));
            }
            
            query = query.Include(x => x.Adresa);

            return query;
        }

        public override Model.MusicShop GetById(int id)
        {
            var entity = context.Set<MusicShop>().Include(x => x.Adresa).FirstOrDefault(x => x.Id == id);

            if (entity != null)
            {
                return mapper.Map<Model.MusicShop>(entity);
            }
            else
            {
                return null;
            }
        }
    }
}
