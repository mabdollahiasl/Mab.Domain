using Mab.Domain.Base.QueryBuilder;
using Mab.Domain.Base.QueryBuilder.CustomQuery;
using System;
using System.Collections.Generic;
using System.Text;

namespace Mab.Domain.Base
{
    public static class DomainConfig
    {
        internal static Type IncludeApplierType { get; private set; }

        public static void AddIncludeQueryBuilder<TQueryApplier>() where TQueryApplier : IIncludeQueryApplier
        {
            IncludeApplierType = typeof(TQueryApplier);
        }
        public static void AddCustomQueryBuilder(params Type[] markertypes)
        {
            CustomQueryAppliers.InitializeTypes(markertypes);
        }
    }
}
