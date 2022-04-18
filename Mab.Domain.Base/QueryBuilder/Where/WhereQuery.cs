using System;
using System.Linq;
using System.Linq.Expressions;

namespace Mab.Domain.Base.QueryBuilder
{
    internal class WhereQuery<TEntity> : IWhereQuery<TEntity> where TEntity : class
    {
        public WhereQuery(Expression<Func<TEntity, bool>> predicate)
        {
            Predicate = predicate;
        }
    
        public IQuery<TEntity> Next { get; set; }

        public Expression<Func<TEntity, bool>> Predicate { get; }

        public IQueryable<TEntity> Apply(IQueryable<TEntity> entities)
        {
            return entities.Where(Predicate);
        }
    }
}
