using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Mab.Domain.Base;
namespace Mab.Domain.Infrastructure.EF
{
    public static class StartupExtenssions
    {
        public static void AddInfrastructureBase(this IServiceCollection service)
        {
            service.AddIncludeQueryBuilder(typeof(IncludeQueryApplier));
        }
    }
}
