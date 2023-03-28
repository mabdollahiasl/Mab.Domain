using Mab.Domain.Base.QueryBuilder.CustomQuery;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Mab.Domain.Base.QueryBuilder
{
    public abstract class CustomQuery<TEntity, TResult> : ICustomQuery<TEntity, TResult> where TEntity : class
    {
    
        public virtual IQueryable<TResult> Query(IQueryable<TEntity> query)
        {
            var queryApplier = CustomQueryAppliers.GetQueryApplier<TEntity, TResult>(GetType());
            var all = queryApplier.Apply(query,this);
            return all;
        }
    }
}
