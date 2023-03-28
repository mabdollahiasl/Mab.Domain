using System;
using System.Collections.Generic;
using System.Text;

namespace Mab.Domain.Base.QueryBuilder
{
    [AttributeUsage(AttributeTargets.Class)]
    public class QueryResolverOfAttribute:Attribute
    {

        public QueryResolverOfAttribute(Type customQueryType)
        {
            CustomQueryType = customQueryType;
        }

        public Type CustomQueryType { get; }
    }
}
