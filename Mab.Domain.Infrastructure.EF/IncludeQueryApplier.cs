using Mab.Domain.Base.QueryBuilder;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
namespace Mab.Domain.Infrastructure.EF
{
    internal class IncludeQueryApplier : IIncludeQueryApplier
    {
        public string PropertyPath { get; set; } = string.Empty;
       

        public IQueryable Apply<TEntity>(IQueryable query) where TEntity : class
        {
            IQueryable<TEntity> curQuery = (IQueryable<TEntity>)query;

            return curQuery.Include(PropertyPath);
        }
        
    }
}
