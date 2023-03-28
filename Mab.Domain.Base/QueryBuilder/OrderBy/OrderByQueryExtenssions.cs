using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace Mab.Domain.Base.QueryBuilder
{
    public static class OrderByQueryExtenssions
    {
        public static IOrderByQuery<TEntity> OrderBy<TEntity, TKey>(this IQuery<TEntity> query,
                                                      Expression<Func<TEntity, TKey>> KeySelector, OrderByType type) where TEntity : class
        {
            var next = new OrderByQuery<TEntity, TKey>(KeySelector, type);
            query.Next = next;
            return next;
        }
        public static IOrderByQuery<TEntity> OrderBy<TEntity,TKey>(this IQuery<TEntity> query,
                                                         Expression<Func<TEntity, TKey>> KeySelector) where TEntity : class
        {
            var next = new OrderByQuery<TEntity,TKey>(KeySelector,OrderByType.Ascending);
            query.Next = next;
            return next;
        }
        public static IOrderByQuery<TEntity> OrderByDescending<TEntity, TKey>(this IQuery<TEntity> query,
                                                         Expression<Func<TEntity, TKey>> KeySelector) where TEntity : class
        {
            var next = new OrderByQuery<TEntity, TKey>(KeySelector,OrderByType.Descending);
            query.Next = next;
            return next;
        }

        public static IOrderByQuery<TEntity> OrderBy<TEntity>(this IQuery<TEntity> query,
                                                         string propertyName) where TEntity : class
        {
            var next = new OrderByQuery<TEntity, object>(propertyName, OrderByType.Ascending);
            query.Next = next;
            return next;
        }
        public static IOrderByQuery<TEntity> OrderByDescending<TEntity>(this IQuery<TEntity> query,
                                                         string propertyName) where TEntity : class
        {
            var next = new OrderByQuery<TEntity, object>(propertyName, OrderByType.Descending);
            query.Next = next;
            return next;
        }
        public static IOrderByQuery<TEntity> OrderBy<TEntity>(this IQuery<TEntity> query,
                                                        string propertyName,OrderByType type) where TEntity : class
        {
            var next = new OrderByQuery<TEntity, object>(propertyName, type);
            query.Next = next;
            return next;
        }
    }

}
