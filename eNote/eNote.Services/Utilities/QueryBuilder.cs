using eNote.Services.Database;
using Microsoft.EntityFrameworkCore;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;

namespace eNote.Services.Helpers
{
    public static class QueryBuilder
    {
        public static IQueryable<TEntity> ApplyChaining<TEntity>(this IQueryable<TEntity> query) where TEntity : class
        {
            if (typeof(TEntity) == typeof(Korisnik))
            {
                return (IQueryable<TEntity>)((IQueryable<Korisnik>)query).Include(x => x.Uloga).Include(x => x.Adresa);
            }
            else if (typeof(TEntity) == typeof(MusicShop))
            {
                return (IQueryable<TEntity>)((IQueryable<MusicShop>)query).Include(x => x.Adresa);
            }
            else if (typeof(TEntity) == typeof(Instrumenti))
            {
                return (IQueryable<TEntity>)((IQueryable<Instrumenti>)query).Include(x => x.VrstaInstrumenta).Include(x => x.MusicShop);
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
