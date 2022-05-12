using System;
using System.Collections.Generic;
using System.Text;

namespace Mab.Domain.Base.Validation.Exceptions
{
    public class NumberZeroException:System.Exception
    {
        public NumberZeroException(string parameterName) : base(parameterName)
        {

        }
    }
}
