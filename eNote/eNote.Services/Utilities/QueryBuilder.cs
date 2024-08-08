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
            if (typeof(T) == typeof(Database.Korisnik))
            {
                return query.Include("Uloga").Include("Adresa");
            }
            if (typeof(T) == typeof(Instrumenti))
            {
                return query.Include("VrstaInstrumenta").Include("MusicShop");
            }
            return query;
        }

        public static IQueryable<T> ApplyPaging<T>(this IQueryable<T> query, int? page, int? pageSize)
        {
            return page.HasValue && pageSize.HasValue
                ? query.Skip(page.Value * pageSize.Value).Take(pageSize.Value)
                : query;
        }

        public static IQueryable<Database.Korisnik> ApplyRole(this IQueryable<Database.Korisnik> query, string roleName)
        {
            return query.Where(k => k.Uloga.Naziv == roleName);
        }
    }
}
