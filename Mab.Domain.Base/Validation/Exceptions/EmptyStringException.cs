using System;
using System.Collections.Generic;
using System.Text;

namespace Mab.Domain.Base.Validation.Exceptions
{
    public class EmptyStringException:System.Exception
    {
        public EmptyStringException(string parameterName):base(parameterName)
        {

        }
    }
}
