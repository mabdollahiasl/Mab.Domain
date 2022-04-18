using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace Mab.Domain.Base.QueryBuilder
{
    public static class WhereQueryExtenssions
    {
        public static IWhereQuery<TEntity> Where<TEntity>(this IQuery<TEntity> query,
                                                          Expression<Func<TEntity, bool>> predicate) where TEntity : class
        {
            var next = new WhereQuery<TEntity>(predicate);
            query.Next = next;
            return next;
        }
    }
}
