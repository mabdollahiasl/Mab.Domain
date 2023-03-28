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
        public OrderByQuery(string propertyName, OrderByType type)
        {
            KeySelector = ToLambda(propertyName);
            Type = type;
        }

        private Expression<Func<TEntity, TKey>> ToLambda(string propertyName)
        {
            var parameter = Expression.Parameter(typeof(TEntity));
            var property = Expression.Property(parameter, propertyName);
            var propAsObject = Expression.Convert(property, typeof(TKey));

            return Expression.Lambda<Func<TEntity, TKey>>(propAsObject, parameter);       
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

        //private static Expression<Func<TEntity, TKey>> ToLambda<TEntity>(string propertyName) where TEntity : class 
        //{
        //    var parameter = Expression.Parameter(typeof(TEntity));
        //    var property = Expression.Property(parameter, propertyName);
        //    var propAsObject = Expression.Convert(property, typeof(TKey));

        //    return Expression.Lambda<Func<TEntity, TKey>>(propAsObject, parameter);
        //}
    }
    public enum OrderByType
    {
        Ascending = 0,
        Descending=1
    }

}
