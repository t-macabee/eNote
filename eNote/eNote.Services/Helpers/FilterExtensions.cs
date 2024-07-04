using eNote.Services.Database;
using Microsoft.EntityFrameworkCore;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;
using System.Reflection;

namespace eNote.Services.Helpers
{
    public static class FilterExtensions
    {
        public static IQueryable<TEntity> Filtering<TEntity, TSearch>(this IQueryable<TEntity> query, TSearch search)
        where TEntity : class
        where TSearch : class
        {
            if (search == null)
            {
                return query;
            }

            var properties = search.GetType().GetProperties(BindingFlags.Public | BindingFlags.Instance);

            foreach (var property in properties)
            {
                var value = property.GetValue(search)?.ToString();
                if (string.IsNullOrWhiteSpace(value))
                {
                    continue;
                }

                switch (property.Name)
                {                    
                    case "Model":
                    case "Proizvodjac":
                        query = ApplyStringFilter(query, property.Name, value, "StartsWith");
                        break;
                    
                    case "Ime":
                    case "Prezime":
                    case "KorisnickoIme":
                    case "Naziv":
                        query = ApplyStringFilter(query, property.Name, value, "Contains");
                        break;
                    
                    case "Grad":
                        query = query.Include("Adresa").Where($"{nameof(Adresa)}.Grad.Contains(@0)", value);
                        break;
                    case "Adresa":
                        query = query.Include("Adresa").Where($"{nameof(Adresa)}.Grad.Contains(@0) OR {nameof(Adresa)}.Ulica.Contains(@0) OR {nameof(Adresa)}.Broj.Contains(@0)", value);
                        break;
                }
            }

            return query;
        }

        private static IQueryable<TEntity> ApplyStringFilter<TEntity>(IQueryable<TEntity> query, string propertyName, string value, string method)
            where TEntity : class
        {
            var parameter = Expression.Parameter(typeof(TEntity), "x");
            var property = Expression.Property(parameter, propertyName);
            var methodInfo = typeof(string).GetMethod(method, new[] { typeof(string) });
            var filter = Expression.Call(property, methodInfo, Expression.Constant(value));
            var lambda = Expression.Lambda<Func<TEntity, bool>>(filter, parameter);
            return query.Where(lambda);
        }
    }
}
