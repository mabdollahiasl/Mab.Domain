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
    public class ReadRepositoryBase<TEntity> : IReadRepositoryBase<TEntity> where TEntity : EntityBase
    {
        protected DbContextBase DbContext { get; }
        protected DbSet<TEntity> DbSet { get; }
        public ReadRepositoryBase(DbContextBase dbContext)
        {

            DbContext = dbContext;
            DbSet = dbContext.Set<TEntity>();
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



        public virtual async Task<TEntity> Get<TKeyType>(TKeyType id, CancellationToken cancellationToken = default)
        {
            var entity = await DbSet.FindAsync(new object[] { id }, cancellationToken);
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


        public async Task<List<TResult>> GetAllByQuery<TResult>(ICustomQuery<TEntity, TResult> query, CancellationToken cancellationToken = default)
        {
            var all = query.Query(DbSet);
            return await all.ToListAsync(cancellationToken);
        }
        public async Task<List<TResult>> GetAllByQuery<TResult>(ICustomQuery<TEntity, TResult> query, int skip, int take, CancellationToken cancellationToken = default)
        {
            var all = query.Query(DbSet);
            return await all.Skip(skip).Take(take).ToListAsync(cancellationToken);
        }

        public async Task<TResult> GetByQuery<TResult>(ICustomQuery<TEntity, TResult> query, CancellationToken cancellationToken = default)
        {
            var all = query.Query(DbSet);
            return await all.FirstOrDefaultAsync(cancellationToken);
        }

        public async Task<int> Count<TResult>(ICustomQuery<TEntity, TResult> query, CancellationToken cancellationToken = default)
        {
            var all = query.Query(DbSet);
            return await all.CountAsync(cancellationToken);
        }
    }
}
