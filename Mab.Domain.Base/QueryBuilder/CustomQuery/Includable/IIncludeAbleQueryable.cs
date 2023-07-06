using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Mab.Domain.Base.QueryBuilder.CustomQuery
{
    public interface IIncludAbleQueryable<out TEntity, out TProperty> : IQueryable<TEntity> where TEntity : class
    {
        string Path { get; set; }
    }
}
