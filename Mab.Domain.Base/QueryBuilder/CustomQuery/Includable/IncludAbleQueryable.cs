using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading;

namespace Mab.Domain.Base.QueryBuilder.CustomQuery.Includable
{
    public class IncludAbleQueryable<TEntity, TProperty> : IIncludAbleQueryable<TEntity, TProperty> where TEntity : class
    {
        private readonly IQueryable<TEntity> _queryable;
        public string Path { get; set; }

        public Type ElementType => _queryable.ElementType;

        public Expression Expression => _queryable.Expression;

        public IQueryProvider Provider => _queryable.Provider;

        public IncludAbleQueryable(IQueryable<TEntity> queryable)
        {
            _queryable = queryable;
        }

      

        internal IIncludAbleQueryable<TEntity, TProperty> Apply()
        {
            if (DomainConfig.IncludeApplierType == null)
            {
                throw new NotImplementedException("IncludeApplier not injected!");
            }
            var applierType = DomainConfig.IncludeApplierType;
            IIncludeQueryApplier applier = (IIncludeQueryApplier)Activator.CreateInstance(applierType);
            applier.PropertyPath = Path;
            var resultQuery = applier.Apply(_queryable);
            return new IncludAbleQueryable<TEntity, TProperty>(resultQuery) { Path = this.Path };
        }

        public IEnumerator<TEntity> GetEnumerator()
        {
            return _queryable.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return _queryable.GetEnumerator();
        }
    }
}
