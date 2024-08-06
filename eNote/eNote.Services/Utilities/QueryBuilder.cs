using eNote.Model;
using eNote.Services.Database;
using eNote.Services.Utilities;
using Microsoft.EntityFrameworkCore;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;

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
                IQueryable<Database.Instrumenti> instrumentiQuery => (IQueryable<T>)(instrumentiQuery.Include(x => x.VrstaInstrumenta).Include(x => x.MusicShop)),
                _ => query
            };
        }
    }

    public class FilterBuilder<T>(IQueryable<T> query) where T : class
    {
        private readonly IQueryable<T> _query = query;
        private readonly List<Func<IQueryable<T>, IQueryable<T>>> _filters = [];

        public FilterBuilder<T> Add(string propertyName, string? value)
        {
            _filters.Add(q => q.FilterBy(propertyName, value));
            return this;
        }

        public FilterBuilder<T> AddNavigation<TProperty>(string navigationProperty, string propertyName, string? value, Expression<Func<T, TProperty>> navigationExpression)
        {
            _filters.Add(q => q.FilterByNavigation(navigationProperty, propertyName, value, navigationExpression));
            return this;
        }

        public IQueryable<T> Build()
        {
            return _filters.Aggregate(_query, (current, filter) => filter(current));
        }
    }
}
