using Mab.Domain.Base.Entities;
using Mab.Domain.Base.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test
{
    public class Teacher : EntityBase<int>, IAggregateRoot
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public List<Room> Rooms { get; set; }
    }
}
