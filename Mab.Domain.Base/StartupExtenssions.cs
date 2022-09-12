using Mab.Domain.Base.QueryBuilder;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace Mab.Domain.Base
{
    public static class StartupExtenssions
    {
        internal static Type IncludeApplierType { get; private set; }

        public static void AddIncludeQueryBuilder<TQueryApplier>(this IServiceCollection service) where TQueryApplier : IIncludeQueryApplier
        {

            IncludeApplierType = typeof(TQueryApplier);
        }
    }
}
