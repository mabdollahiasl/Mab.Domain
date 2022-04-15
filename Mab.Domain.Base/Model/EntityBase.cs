using System;
using System.Collections.Generic;
using System.Text;

namespace Mab.Domain.Base.Model
{
    public class EntityBase<TKeyType>
    {
        public TKeyType Id { get; set; }
    }
   
}
