using System;
using System.Collections.Generic;
using System.Text;

namespace Mab.Domain.Base.Validation
{
    public class Validation:IValidation
    {
        public static IValidation Throw { get;}=new Validation();
        
    }
}
