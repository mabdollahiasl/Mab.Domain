using Mab.Domain.Base.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Mab.Domain.Base.Interfaces
{
    public interface IWriteRepositoryBase<TEntity, TKeyType> where TEntity : EntityBase<TKeyType>, IAggregateRoot
    {
        Task Add(TEntity entity);
        Task Update(TKeyType id,TEntity entity);
        Task Delete(TKeyType id);
        IUnitOfWork UnitOfWork { get; }
       
    }
}
