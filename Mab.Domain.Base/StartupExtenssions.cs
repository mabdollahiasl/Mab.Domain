using Mab.Domain.Base.QueryBuilder;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace Mab.Domain.Base
{
    public static class StartupExtenssions
    {
        public static IIncludeQueryApplier IncludeApplier { get; private set; }

        public static void AddIncludeQueryBuilder(this IServiceCollection service, IIncludeQueryApplier queryApplier)
        {
            IncludeApplier = queryApplier;
        }
    }
}
