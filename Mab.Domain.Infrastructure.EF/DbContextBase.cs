using Mab.Domain.Base.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mab.Domain.Infrastructure.EF
{
    public class DbContextBase : DbContext, IUnitOfWork
    {
        public virtual async Task SaveChanges(CancellationToken cancellationToken = default)
        {
           await base.SaveChangesAsync(cancellationToken);
        }
    }
}
