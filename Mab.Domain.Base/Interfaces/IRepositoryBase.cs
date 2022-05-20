using Mab.Domain.Base.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Mab.Domain.Base.Interfaces
{
    public interface IRepositoryBase<TEntity>:IReadRepositoryBase<TEntity>, IWriteRepositoryBase<TEntity> where TEntity : EntityBase,IAggregateRoot
    {

    }
}
