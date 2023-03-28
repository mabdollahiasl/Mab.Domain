using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace Mab.Domain.Base.QueryBuilder
{
    /// <summary>
    /// A generic query builder for entity type based on specification design pattern, for making query generate a child class and inherits from this class and
    /// then create your query in the constructor like Query.OrderBy ...
    /// </summary>
    /// <typeparam name="TEntity">the entity type</typeparam>
    public class QueryBuilder<TEntity>: IQueryBuilder<TEntity> where TEntity : class
    {
        protected QueryBuilder()
        {
            Query = new Query<TEntity>();
            
        }

        protected IQuery<TEntity> Query { get; }

        public IQueryable<TEntity> Apply(IQueryable<TEntity> entities)
        {
            var query = this.Query;
            var result = entities;
            while(query != null)
            {
                result = query.Apply(result);
                query = query.Next;
            }
            return result;
        }
    }
    public interface IQueryBuilder<TEntity> where TEntity : class
    {
        IQueryable<TEntity> Apply(IQueryable<TEntity> entities);
    }
    public interface IQuery<TEntity>:IQuery where TEntity : class
    {
        IQuery<TEntity> Next { get; set; }
        IQueryable<TEntity> Apply(IQueryable<TEntity> entities);
    }
    public interface IQuery
    {

    }
}
