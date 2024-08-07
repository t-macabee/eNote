using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace eNote.Services.Utilities
{
    public class FilterBuilder<T>(IQueryable<T> query) where T : class
    {
        private readonly IQueryable<T> query = query;
        private readonly List<Func<IQueryable<T>, IQueryable<T>>> filters = [];

        public FilterBuilder<T> Add(string propertyName, string? value)
        {
            filters.Add(q => q.FilterBy(propertyName, value));
            return this;
        }

        public FilterBuilder<T> AddNavigation<TProperty>(string navigationProperty, string propertyName, string? value)
        {
            filters.Add(q => q.FilterByNavigation<T, TProperty>(navigationProperty, propertyName, value));
            return this;
        }
        public IQueryable<T> Build()
        {
            return filters.Aggregate(query, (current, filter) => filter(current));
        }
    }

    public static class FilterBuilderExtensions
    {
        public static IQueryable<T> FilterBy<T>(this IQueryable<T> query, string propertyName, string? value) where T : class
        {
            if (string.IsNullOrEmpty(value))
                return query;

            return query.Where(x => EF.Property<string>(x, propertyName).StartsWith(value));
        }

        public static IQueryable<T> FilterByNavigation<T, TProperty>(this IQueryable<T> query, string navigationProperty, string propertyName, string? value) where T : class
        {
            if (string.IsNullOrEmpty(value))
                return query;

            return query.Where(x => EF.Property<TProperty>(EF.Property<object>(x, navigationProperty), propertyName) != null
                                     && EF.Property<string>(EF.Property<object>(x, navigationProperty), propertyName).StartsWith(value));
        }
    }
}

