using eNote.Services.Database;
using MapsterMapper;
using Microsoft.EntityFrameworkCore;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;

namespace eNote.Services.Helpers
{
    public static class QueryBuilder
    {
        public static IQueryable<T> ApplyChaining<T>(this IQueryable<T> query) where T : class
        {
            return query switch
            {
                IQueryable<Korisnik> korisnikQuery => (IQueryable<T>)(korisnikQuery.Include(x => x.Uloga).Include(x => x.Adresa)),
                IQueryable<MusicShop> musicShopQuery => (IQueryable<T>)(musicShopQuery.Include(x => x.Adresa)),
                IQueryable<Instrumenti> instrumentiQuery => (IQueryable<T>)(instrumentiQuery.Include(x => x.VrstaInstrumenta).Include(x => x.MusicShop)),
                _ => query
            };
        }

        public static IQueryable<T> ApplyFilters<T>(this IQueryable<T> query, IEnumerable<Func<IQueryable<T>, IQueryable<T>>> filters)
        {
            return filters.Aggregate(query, (current, filter) => filter(current));
        }

        public static IQueryable<T> ApplyPaging<T>(this IQueryable<T> query, int? page, int? pageSize)
        {
            return page.HasValue && pageSize.HasValue ? query.Skip(page.Value * pageSize.Value).Take(pageSize.Value) : query;
        }       
    }
}
