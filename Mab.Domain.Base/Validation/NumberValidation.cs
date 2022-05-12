using Mab.Domain.Base.Validation.Exceptions;
using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;

namespace Mab.Domain.Base.Validation
{
    public static class NumberValidation
    {
        public static void OnZeroAndSmaller(this IValidation validation, int data, [CallerMemberName] string parameterName = "")
        {
            if (data <= 0)
            {
                throw new NumberZeroException(parameterName);
            }
        }
        public static void OnZeroAndSmaller(this IValidation validation, double data, [CallerMemberName] string parameterName = "")
        {
            if (data <= 0)
            {
                throw new NumberZeroException(parameterName);
            }
        }
        public static void OnZeroAndSmaller(this IValidation validation, decimal data, [CallerMemberName] string parameterName = "")
        {
            if (data <= 0)
            {
                throw new NumberZeroException(parameterName);
            }
        }
    }
}
