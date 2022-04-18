using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Mab.Domain.Base.QueryBuilder
{
    internal class Query<TEntity> : IQuery<TEntity> where TEntity : class
    {
        public IQuery<TEntity> Next { get; set; }

        public IQueryable<TEntity> Apply(IQueryable<TEntity> entities)
        {
            return entities;
        }
    }
}
