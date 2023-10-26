using System;
using System.Linq;

namespace Mab.Domain.Base.QueryBuilder
{
    internal class IncludableQuery<TEntity, TProperty> : IIncludableQuery<TEntity, TProperty> where TEntity : class
    {
        public IncludableQuery()
        {
        }
        public string Path { get; set; }
        public IQuery<TEntity> Next { get; set; }

        public IQueryable<TEntity> Apply(IQueryable<TEntity> entities)
        {
            if (DomainConfig.IncludeApplierType == null)
            {
                throw new NotImplementedException("IncludeApplier not injected!");
            }
            var applierType = DomainConfig.IncludeApplierType;
            IIncludeQueryApplier applier = (IIncludeQueryApplier)Activator.CreateInstance(applierType);
            applier.PropertyPath = Path;
            return applier.Apply(entities);
        } 
    }
}
