using Microsoft.EntityFrameworkCore;
using System;
using System.Linq.Expressions;
using System.Reflection;


namespace eNote.Services.Utilities
{
    public static class FilterBuilder
    {
        public static IQueryable<T> FilterBy<T>(this IQueryable<T> query, string propertyName, string? value) where T : class
        {
            if (string.IsNullOrEmpty(value))
                return query;

            var parameter = Expression.Parameter(typeof(T), "x");
            var property = Expression.Property(parameter, propertyName);
            var stringValue = Expression.Constant(value);
            var startsWith = Expression.Call(property, "StartsWith", null, stringValue);
            var lambda = Expression.Lambda<Func<T, bool>>(startsWith, parameter);

            return query.Where(lambda);
        }

        public static IQueryable<T> FilterByNavigation<T, TProperty>(this IQueryable<T> query, string navigationProperty, string propertyName, string? value, Expression<Func<T, TProperty>> navigationExpression) where T : class
        {
            if (string.IsNullOrEmpty(value))
                return query;

            var parameter = Expression.Parameter(typeof(T), "x");
            var navigation = Expression.Property(parameter, navigationProperty);
            var property = Expression.Property(navigation, propertyName);
            var nullCheck = Expression.NotEqual(navigation, Expression.Constant(null, navigation.Type));
            var stringValue = Expression.Constant(value);
            var startsWith = Expression.Call(property, "StartsWith", null, stringValue);
            var combinedExpression = Expression.AndAlso(nullCheck, startsWith);
            var lambda = Expression.Lambda<Func<T, bool>>(combinedExpression, parameter);

            return query.Include(navigationExpression).Where(lambda);
        }
    }
}

