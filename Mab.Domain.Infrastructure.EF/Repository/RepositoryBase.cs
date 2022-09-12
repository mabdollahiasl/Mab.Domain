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
    public abstract class RepositoryBase<TEntity> : IRepositoryBase<TEntity> where TEntity : EntityBase, IAggregateRoot
    {
        protected DbContextBase DbContext { get; }
        protected DbSet<TEntity> DbSet { get; }
        public RepositoryBase(DbContextBase dbContext)
        {
            
            DbContext = dbContext;
            DbSet = dbContext.Set<TEntity>();
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
        public virtual async Task<int> Count(IQueryBuilder<TEntity> query, CancellationToken cancellationToken = default)
        {
            var all = query.Apply(DbSet);
            return await all.CountAsync(cancellationToken);
        }

        public virtual async Task<int> Count(CancellationToken cancellationToken = default)
        {
            return await DbSet.CountAsync(cancellationToken);
        }

        public virtual async Task Delete<TKeyType>(TKeyType id, CancellationToken cancellationToken = default)
        {
            var entityToDelete = await DbSet.FindAsync(new object[] { id }, cancellationToken);
            if (entityToDelete != null)
            {
                DbSet.Remove(entityToDelete);
            }
        }

        public virtual async Task<TEntity> Get<TKeyType>(TKeyType id, CancellationToken cancellationToken = default)
        {
            var entity = await DbSet.FindAsync(new object[] { id },cancellationToken);
            return entity;
        }
        public virtual async Task<TEntity> GetByQuery(IQueryBuilder<TEntity> query, CancellationToken cancellationToken = default) 
        {
            var all = query.Apply(DbSet);
            return await all.FirstOrDefaultAsync(cancellationToken);
        }

        public virtual async Task<List<TEntity>> GetAll(CancellationToken cancellationToken = default)
        {
            return await DbSet.ToListAsync(cancellationToken);
        }
        public virtual async Task<List<TEntity>> GetAllByQuery(IQueryBuilder<TEntity> query, CancellationToken cancellationToken = default)
        {
            var all = query.Apply(DbSet);
            return await all.ToListAsync(cancellationToken);
        }

        public virtual async Task<List<TEntity>> GetAllByQuery(IQueryBuilder<TEntity> query, int skip, int take, CancellationToken cancellationToken = default)
        {
            var all = query.Apply(DbSet);
            return await all.Skip(skip).Take(take).ToListAsync(cancellationToken);
        }

        public virtual Task Update(TEntity entity, CancellationToken cancellationToken = default)
        {
            DbSet.Update(entity);
            return Task.CompletedTask;
        }

       

       
    }
}
