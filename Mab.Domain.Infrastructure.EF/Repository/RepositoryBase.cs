using Mab.Domain.Base.Entities;
using Mab.Domain.Base.Interfaces;
using Mab.Domain.Base.QueryBuilder;
using Mab.Domain.Base.QueryBuilder.CustomQuery;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

#pragma warning disable CS8603 // Possible null reference return.

namespace Mab.Domain.Infrastructure.EF.Repository
{
    public abstract class RepositoryBase<TEntity> : ReadRepositoryBase<TEntity>, IRepositoryBase<TEntity> where TEntity : EntityBase, IAggregateRoot
    {
        protected RepositoryBase(DbContextBase dbContext) : base(dbContext)
        {
        }

        public IUnitOfWork UnitOfWork => DbContext;

        public virtual async Task Add(TEntity entity, CancellationToken cancellationToken = default)
        {
            await DbSet.AddAsync(entity, cancellationToken);
        }
        public virtual async Task AddRange(IEnumerable<TEntity> entity, CancellationToken cancellationToken = default)
        {
            await DbSet.AddRangeAsync(entity, cancellationToken);
        }

        public virtual async Task Delete<TKeyType>(TKeyType id, CancellationToken cancellationToken = default)
        {
            var entityToDelete = await DbSet.FindAsync(new object[] { id }, cancellationToken);
            if (entityToDelete != null)
            {
                DbSet.Remove(entityToDelete);
            }
        }

        public async Task DeleteRange<TKeyType>(IEnumerable<TKeyType> ids, CancellationToken cancellationToken = default)
        {
            List<TEntity> entitiesToDelete = new List<TEntity>();
            foreach (var id in ids)
            {
                var item = await DbSet.FindAsync(new object[] { id }, cancellationToken);
                if (item != null)
                {
                    entitiesToDelete.Add(item);
                }
            }
            DbSet.RemoveRange(entitiesToDelete);
        }

        public Task DeleteRange(IEnumerable<TEntity> entitiesToDelete, CancellationToken cancellationToken = default)
        {
            DbSet.RemoveRange(entitiesToDelete);
            return Task.CompletedTask;
        }

        public virtual Task Update(TEntity entity, CancellationToken cancellationToken = default)
        {
            DbSet.Update(entity);
            return Task.CompletedTask;
        }


    }
}
