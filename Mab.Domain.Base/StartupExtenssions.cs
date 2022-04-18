using Mab.Domain.Base.QueryBuilder;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace Mab.Domain.Base
{
    public static class StartupExtenssions
    {
        public static IQueryApplier IncludeApplier { get; private set; }

        public static void AddIncludeQueryBuilder(this IServiceCollection service, IQueryApplier queryApplier)
        {
            IncludeApplier = queryApplier;
        }
    }
}
