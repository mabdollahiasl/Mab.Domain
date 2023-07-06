using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace Mab.Domain.Base.QueryBuilder.CustomQuery
{
    //Queryable Extensions
    public static class QueryableOrderByExtensions
    {
        public static IQueryable<TEntity> OrderBy<TEntity>(this IQueryable<TEntity> query,
                                                      string propertyName) where TEntity : class
        {

            var keySelector = ToLambda<TEntity, object>(propertyName);
            return query.OrderBy(keySelector);


        }
        public static IQueryable<TEntity> OrderByDescending<TEntity>(this IQueryable<TEntity> query,
                                                      string propertyName) where TEntity : class
        {
            var keySelector = ToLambda<TEntity, object>(propertyName);
            return query.OrderByDescending(keySelector);
        }
        public static IQueryable<TEntity> OrderBy<TEntity>(this IQueryable<TEntity> query,
                                                           string propertyName, OrderByType type) where TEntity : class
        {
            if (type == OrderByType.Ascending)
            {
                return query.OrderBy(propertyName);
            }
            else
            {
                return query.OrderByDescending(propertyName);
            }
        }

        public static Expression<Func<TEntity, TKey>> ToLambda<TEntity, TKey>(string propertyName)
        {
            var parameter = Expression.Parameter(typeof(TEntity));
            var property = Expression.Property(parameter, propertyName);
            var propAsObject = Expression.Convert(property, typeof(TKey));

            return Expression.Lambda<Func<TEntity, TKey>>(propAsObject, parameter);
        }
    }
}
