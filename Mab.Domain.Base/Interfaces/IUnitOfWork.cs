using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Mab.Domain.Base.Interfaces
{
    public interface IUnitOfWork
    {
        Task SaveChanges();
    }
}
