using eNote.Model.Pagination;
using eNote.Model.SearchObjects;
using eNote.Services.Database;
using eNote.Services.Interfaces;
using MapsterMapper;
using Microsoft.EntityFrameworkCore;

namespace eNote.Services.Services
{
    public class MusicShopService : BaseService<Model.MusicShop, MusicShopSearchObject, Database.MusicShop>, IMusicShopService
    {
        public MusicShopService(eNoteContext context, IMapper mapper) : base(context, mapper)
        {
        }

        public override IQueryable<MusicShop> AddFilter(MusicShopSearchObject search, IQueryable<MusicShop> query)
        {
            var filteredQuery = base.AddFilter(search, query);

            if (!string.IsNullOrWhiteSpace(search?.NazivGTE))
            {
                filteredQuery = filteredQuery.Where(x => x.Naziv.Contains(search.NazivGTE));
            }

            if (!string.IsNullOrWhiteSpace(search?.LokacijaGTE))
            {
                filteredQuery = filteredQuery.Where(x => x.Adresa.Contains(search.LokacijaGTE));
            }

            return filteredQuery;
        }
    }
}
