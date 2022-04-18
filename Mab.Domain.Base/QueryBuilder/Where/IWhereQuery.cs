using System;
using System.Linq.Expressions;

namespace Mab.Domain.Base.QueryBuilder
{
    public interface IWhereQuery<TEntity> : IQuery<TEntity> where TEntity : class
    {
        Expression<Func<TEntity, bool>> Predicate { get; }
    }
}
