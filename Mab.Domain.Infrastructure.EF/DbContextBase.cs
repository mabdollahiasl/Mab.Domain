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
        public DbContextBase(DbContextOptions options):base(options)
        {

        }
        public DbContextBase():base()
        {

        }
        public virtual async Task SaveChanges(CancellationToken cancellationToken = default)
        {
           await base.SaveChangesAsync(cancellationToken);
        }

        public Task BeginWork()
        {
            this.Database.BeginTransaction(System.Data.IsolationLevel.Serializable);
            return Task.CompletedTask;
        }

        public Task CommitWork()
        {
            this.Database.CommitTransaction();
            return Task.CompletedTask;
        }

        public Task DeleteWork()
        {
            this.Database.RollbackTransaction();
            return Task.CompletedTask;
        }
    }
}
