using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Mab.Domain.Base.QueryBuilder
{
    public interface IQueryApplier
    {
        IQueryable<TEntity> Apply<TEntity>(IQueryable<TEntity> query) where TEntity:class;
    }
}
