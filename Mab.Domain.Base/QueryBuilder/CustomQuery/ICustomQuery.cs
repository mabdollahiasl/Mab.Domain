using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Mab.Domain.Base.QueryBuilder
{
    public interface ICustomQuery<TEntity, TResult> where TEntity : class
    {
        IQueryable<TResult> Query(IQueryable<TEntity> query);
    }
}
