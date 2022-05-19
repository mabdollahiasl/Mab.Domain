using Mab.Domain.Base.Entities;
using Mab.Domain.Base.QueryBuilder;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Mab.Domain.Base.Interfaces
{
    public interface IReadRepositoryBase<TEntity, TKeyType> where TEntity:EntityBase<TKeyType>, IAggregateRoot
    {
        Task<List<TEntity>> GetAll();
        Task<TEntity> Get(TKeyType id);
        Task<List<TEntity>> GetAll(Func<TEntity, bool> predicate);
        Task<TEntity> Get(IQuery<TEntity> query);
        Task<List<TEntity>> GetAll(IQuery<TEntity> query);
        Task<List<TEntity>> GetAll(IQuery<TEntity> query, int skip, int take);

    }
}
