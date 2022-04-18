using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace Mab.Domain.Base.QueryBuilder
{
    public static class OrderByQueryExtenssions
    {
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
    }

}
