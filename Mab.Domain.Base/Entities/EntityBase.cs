using System;
using System.Collections.Generic;
using System.Text;

namespace Mab.Domain.Base.Entities
{
    public class EntityBase<TKeyType>:EntityBase
    {
        public TKeyType Id { get; set; }
    }
    public abstract class EntityBase
    {

    }
   
}
