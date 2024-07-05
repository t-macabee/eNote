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
            if (typeof(T) == typeof(Korisnik))
            {
                return (IQueryable<T>)((IQueryable<Korisnik>)query).Include(x => x.Uloga).Include(x => x.Adresa);
            }
            else if (typeof(T) == typeof(MusicShop))
            {
                return (IQueryable<T>)((IQueryable<MusicShop>)query).Include(x => x.Adresa);
            }
            else if (typeof(T) == typeof(Instrumenti))
            {
                return (IQueryable<T>)((IQueryable<Instrumenti>)query).Include(x => x.VrstaInstrumenta).Include(x => x.MusicShop);
            }
            return query;
        }

        public static IQueryable<T> ApplyFilters<T>(this IQueryable<T> query, IEnumerable<Func<IQueryable<T>, IQueryable<T>>> filters)
        {
            foreach (var filter in filters)
            {
                query = filter(query);
            }

            return query;
        }

        public static IQueryable<T> ApplyPaging<T>(this IQueryable<T> query, int? page, int? pageSize)
        {
            if (page.HasValue && pageSize.HasValue)
            {
                return query.Skip(page.Value * pageSize.Value).Take(pageSize.Value);
            }
            return query;
        }       
    }
}
