using Mab.Domain.Base.Model;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace Mab.Domain.Base.QueryBuilder
{
    public static class WhereQueryExtenssion
    {
        public static IWhereQuery<TEntity> Where<TEntity>(this Query<TEntity> query, Expression<Func<TEntity,bool>> predicate) where TEntity : class
        {
            var next = new WhereQuery<TEntity>(predicate);
            query.Next = next;
            return next;
        }
    }
    public interface IWhereQuery<TEntity> : IQuery<TEntity> where TEntity : class
    {
        Expression<Func<TEntity, bool>> Predicate { get; }
    }
    public class WhereQuery<TEntity> : IWhereQuery<TEntity> where TEntity : class
    {
        public WhereQuery(Expression<Func<TEntity, bool>> predicate)
        {
            Predicate = predicate;
        }

        public Expression<Func<TEntity, bool>> Predicate { get; }

        public IQuery<TEntity> Next { get ; set; }
    }
}
