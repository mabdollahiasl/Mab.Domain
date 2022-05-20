using Mab.Domain.Base.Entities;
using Mab.Domain.Base.Interfaces;
using Mab.Domain.Base.QueryBuilder;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

#pragma warning disable CS8603 // Possible null reference return.

namespace Mab.Domain.Infrastructure.EF.Repository
{
    public class RepositoryBase<TEntity> : IRepositoryBase<TEntity> where TEntity : EntityBase, IAggregateRoot
    {
        protected DbContextBase DbContext { get; }
        protected DbSet<TEntity> DbSet { get; }
        public RepositoryBase(DbContextBase dbContext)
        {
            DbContext = dbContext;
            DbSet = dbContext.Set<TEntity>();
        }
        public IUnitOfWork UnitOfWork => DbContext;

        public async Task Add(TEntity entity, CancellationToken cancellationToken = default)
        {
            await DbSet.AddAsync(entity, cancellationToken);
        }

        public async Task<int> Count(IQuery<TEntity> query, CancellationToken cancellationToken = default)
        {
            var all = query.Apply(DbSet);
            return await all.CountAsync(cancellationToken);
        }

        public async Task<int> Count(CancellationToken cancellationToken = default)
        {
            return await DbSet.CountAsync(cancellationToken);
        }

        public async Task Delete<TKeyType>(TKeyType id, CancellationToken cancellationToken = default)
        {
            var entityToDelete = await DbSet.FindAsync(id,cancellationToken);
            if (entityToDelete != null)
            {
                DbSet.Remove(entityToDelete);
            }
        }

        public async Task<TEntity> Get<TKeyType>(TKeyType id, CancellationToken cancellationToken = default)
        {
            var entity = await DbSet.FindAsync(id, cancellationToken);
            return entity;
        }
        public async Task<TEntity> Get(IQuery<TEntity> query, CancellationToken cancellationToken = default)
        {
            var all = query.Apply(DbSet);
            return await all.FirstOrDefaultAsync(cancellationToken);
        }

        public async Task<List<TEntity>> GetAll(CancellationToken cancellationToken = default)
        {
            return await DbSet.ToListAsync(cancellationToken);
        }
        public async Task<List<TEntity>> GetAll(IQuery<TEntity> query, CancellationToken cancellationToken = default)
        {
            var all = query.Apply(DbSet);
            return await all.ToListAsync(cancellationToken);
        }

        public async Task<List<TEntity>> GetAll(IQuery<TEntity> query, int skip, int take, CancellationToken cancellationToken = default)
        {
            var all = query.Apply(DbSet);
            return await all.Skip(skip).Take(take).ToListAsync(cancellationToken);
        }

        public Task Update(TEntity entity, CancellationToken cancellationToken = default)
        {
            DbSet.Update(entity);
            return Task.CompletedTask;
        }
    }
}
