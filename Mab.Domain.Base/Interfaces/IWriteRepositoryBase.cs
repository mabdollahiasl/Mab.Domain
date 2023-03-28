using Mab.Domain.Base.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Mab.Domain.Base.Interfaces
{
    public interface IWriteRepositoryBase<TEntity> where TEntity : EntityBase, IAggregateRoot
    {
        Task Add(TEntity entity, CancellationToken cancellationToken = default);
        Task AddRange(IEnumerable<TEntity> entities, CancellationToken cancellationToken = default);

        Task Update(TEntity entity, CancellationToken cancellationToken = default);
        Task Delete<TKeyType>(TKeyType id, CancellationToken cancellationToken = default);
        Task DeleteRange<TKeyType>(IEnumerable<TKeyType> id, CancellationToken cancellationToken = default);
        Task DeleteRange(IEnumerable<TEntity> entities, CancellationToken cancellationToken = default);

        IUnitOfWork UnitOfWork { get; }

    }
}
