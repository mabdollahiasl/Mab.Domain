using Mab.Domain.Base.Entities;
using Mab.Domain.Base.QueryBuilder;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Mab.Domain.Base.Interfaces
{
    public interface IReadRepositoryBase<TEntity> where TEntity:EntityBase, IAggregateRoot
    {
        Task<List<TEntity>> GetAll(CancellationToken cancellationToken = default(CancellationToken));
        Task<TEntity> Get<TKeyType>(TKeyType id, CancellationToken cancellationToken = default(CancellationToken));
        Task<TEntity> Get(IQuery<TEntity> query, CancellationToken cancellationToken = default(CancellationToken));
        Task<List<TEntity>> GetAll(IQuery<TEntity> query, CancellationToken cancellationToken = default(CancellationToken));
        Task<List<TEntity>> GetAll(IQuery<TEntity> query, int skip, int take, CancellationToken cancellationToken = default(CancellationToken));
        Task<int> Count(IQuery<TEntity> query, CancellationToken cancellationToken = default(CancellationToken));
        Task<int> Count(CancellationToken cancellationToken = default(CancellationToken));

    }
}
