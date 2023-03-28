using Mab.Domain.Base.Entities;
using Mab.Domain.Base.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test
{
    public class Room : EntityBase<int>, IAggregateRoot
    {
        public string Name { get; set; }
        public Room Base { get; set; }
    }
}
