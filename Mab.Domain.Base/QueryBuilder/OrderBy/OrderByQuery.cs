using System;
using System.Linq;
using System.Linq.Expressions;

namespace Mab.Domain.Base.QueryBuilder
{
    internal class OrderByQuery<TEntity,TKey> : IOrderByQuery<TEntity> where TEntity : class
    {
        public OrderByQuery(Expression<Func<TEntity, TKey>> keySelector,OrderByType type)
        {
            KeySelector = keySelector;
            Type = type;
        }

        public IQuery<TEntity> Next { get; set; }
        public Expression<Func<TEntity, TKey>> KeySelector { get; }
        public OrderByType Type { get; }

        public IQueryable<TEntity> Apply(IQueryable<TEntity> entities)
        {
            switch (Type)
            {
                case OrderByType.Ascending:
                    return entities.OrderBy(KeySelector);
                case OrderByType.Descending:
                    return entities.OrderByDescending(KeySelector);
                default:
                    throw new NotSupportedException();
            }
        }
    }
    public enum OrderByType
    {
        Ascending = 0,
        Descending=1
    }

}
