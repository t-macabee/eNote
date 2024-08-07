using eNote.Model;
using eNote.Services.Database;
using eNote.Services.Utilities;
using Microsoft.EntityFrameworkCore;

namespace eNote.Services.Helpers
{
    public static class QueryBuilder
    {
        public static IQueryable<T> ApplyFilters<T>(IQueryable<T> query, Action<FilterBuilder<T>> filterAction) where T : class
        {
            var builder = new FilterBuilder<T>(query);
            filterAction(builder);
            return builder.Build();
        }

        public static IQueryable<T> ApplyChaining<T>(IQueryable<T> query) where T : class
        {
            return query switch
            {
                IQueryable<Database.Korisnik> korisnikQuery => (IQueryable<T>)(korisnikQuery.Include(x => x.Uloga).Include(x => x.Adresa)),
                IQueryable<Instrumenti> instrumentiQuery => (IQueryable<T>)(instrumentiQuery.Include(x => x.VrstaInstrumenta).Include(x => x.MusicShop)),
                _ => query
            };
        }



        public static IQueryable<T> ApplyPaging<T>(this IQueryable<T> query, int? page, int? pageSize)
        {
            return page.HasValue && pageSize.HasValue ? query.Skip(page.Value * pageSize.Value).Take(pageSize.Value) : query;
        }
    }
}
