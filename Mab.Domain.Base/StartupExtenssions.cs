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

        public static void AddIncludeQueryBuilder(this IServiceCollection service, Type queryApplierType)
        {
            if(queryApplierType !=typeof(IIncludeQueryApplier))
            {
                throw new Exception("queryApplierType type must be IIncludeQueryApplier");
            }
            IncludeApplierType = queryApplierType;
        }
    }
}
