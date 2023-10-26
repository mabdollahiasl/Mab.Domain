using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Mab.Domain.Base;
using System.Reflection;
using Mab.Domain.Base.QueryBuilder.CustomQuery;

namespace Mab.Domain.Infrastructure.EF
{
    public static class StartupExtenssions
    {
        public static void AddInfrastructureBase(this IServiceCollection service)
        {
            DomainConfig.AddIncludeQueryBuilder<IncludeQueryApplier>();
        }
    }
}
