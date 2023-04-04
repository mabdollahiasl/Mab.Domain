using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Mab.Domain.Base.Interfaces
{
    public interface IUnitOfWork
    {
        Task SaveChanges(CancellationToken cancellationToken = default(CancellationToken));
        Task BeginWork();
        Task CommitWork();
        Task DeleteWork();
    }
}
