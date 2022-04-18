using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace Mab.Domain.Base.QueryBuilder
{
    public class QueryBuilder<TEntity> where TEntity : class
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
    public interface IQuery<TEntity>:IQuery where TEntity : class
    {
        IQuery<TEntity> Next { get; set; }
        IQueryable<TEntity> Apply(IQueryable<TEntity> entities);
    }
    public interface IQuery
    {

    }
}
