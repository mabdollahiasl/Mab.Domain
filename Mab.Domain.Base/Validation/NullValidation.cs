using Mab.Domain.Base.Validation.Exceptions;
using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;

namespace Mab.Domain.Base.Validation
{
    public static class NullValidation
    {
        public static void OnNull(this IValidation validation,object data,[CallerMemberName]string parameterName="")
        {
            if (data == null)
            {
                throw new ArgumentNullException(parameterName);
            }
        }
        public static void OnNullOrEmpty(this IValidation validation, string data, [CallerMemberName] string parameterName = "")
        {
            if (string.IsNullOrEmpty(data))
            {
                throw new EmptyStringException(parameterName);
            }
        }
    }
}
