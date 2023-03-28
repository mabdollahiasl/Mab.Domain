using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Mab.Domain.Base.QueryBuilder.CustomQuery
{
    public interface ICustomQueryApplier<TEntity, TResult> where TEntity : class
    {
        IQueryable<TResult> Apply(IQueryable<TEntity> entities,ICustomQuery<TEntity,TResult> query); 
    }
}
