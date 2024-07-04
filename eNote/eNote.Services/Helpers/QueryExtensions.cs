using eNote.Services.Database;
using Microsoft.EntityFrameworkCore;
using System.Linq.Dynamic.Core;

namespace eNote.Services.Helpers
{
    public static class QueryExtensions
    { 
        public static IQueryable<TEntity> QueryChain<TEntity>(this IQueryable<TEntity> query) where TEntity: class
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

        public static TEntity CompareId<TEntity>(this IQueryable<TEntity> query, int id) where TEntity : class
        {
            return query.FirstOrDefault(x => EF.Property<int>(x, "Id") == id);
        }
        
        public static TEntity CompareProperty<TEntity>(this IQueryable<TEntity> query, string propertyName, object value)
            where TEntity : class
        {
            return query.FirstOrDefault($"{propertyName} == @0", value);
        }
    }
}
