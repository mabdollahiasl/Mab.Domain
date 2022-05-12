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
            if (StartupExtenssions.IncludeApplier == null)
            {
                throw new NotImplementedException("IncludeApplier not injected!");
            }
            var applier = StartupExtenssions.IncludeApplier;
            applier.PropertyPath = Path;
            return (IQueryable<TEntity>)applier.Apply(entities);
        } 
    }
}
