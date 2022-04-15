using Mab.Domain.Base.Model;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace Mab.Domain.Base.QueryBuilder
{
    public class Query<TEntity>:IQuery<TEntity> where TEntity : class
    {
        internal Queue<IQuery<TEntity>> Queries=new Queue<IQuery<TEntity>>();
        public Query()
        {
              
        }

        public IQuery<TEntity> Next { get ; set; }
    }
    public interface IQuery<TEntity> where TEntity : class
    {
        IQuery<TEntity> Next { get; set; }
    }
}
