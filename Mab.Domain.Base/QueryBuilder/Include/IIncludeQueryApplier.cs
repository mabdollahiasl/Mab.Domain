using System;
using System.Collections.Generic;
using System.Text;

namespace Mab.Domain.Base.QueryBuilder
{
    public interface IIncludeQueryApplier:IQueryApplier
    {
        string PropertyPath { get; set; }
    }
}
