using Mab.Domain.Base.Entities;
using Mab.Domain.Base.QueryBuilder;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Mab.Domain.Base.Interfaces
{
    public interface IReadRepositoryBase<TEntity> where TEntity : EntityBase
    {
        Task<TEntity> Get<TKeyType>(TKeyType id, CancellationToken cancellationToken = default(CancellationToken));
        Task<TEntity> GetByQuery(IQueryBuilder<TEntity> query, CancellationToken cancellationToken = default(CancellationToken));
        Task<List<TEntity>> GetAll(CancellationToken cancellationToken = default(CancellationToken));
        Task<List<TEntity>> GetAllByQuery(IQueryBuilder<TEntity> query, CancellationToken cancellationToken = default(CancellationToken));


        Task<List<TEntity>> GetAllByQuery(IQueryBuilder<TEntity> query, int skip, int take, CancellationToken cancellationToken = default(CancellationToken));

        Task<List<TResult>> GetAllByQuery<TResult>(ICustomQuery<TEntity, TResult> query, CancellationToken cancellationToken = default(CancellationToken));
        Task<List<TResult>> GetAllByQuery<TResult>(ICustomQuery<TEntity, TResult> query, int skip, int take, CancellationToken cancellationToken = default(CancellationToken));
        Task<TResult> GetByQuery<TResult>(ICustomQuery<TEntity, TResult> query, CancellationToken cancellationToken = default(CancellationToken));


        Task<int> Count(IQueryBuilder<TEntity> query, CancellationToken cancellationToken = default(CancellationToken));
        Task<int> Count(CancellationToken cancellationToken = default(CancellationToken));


    }
}
