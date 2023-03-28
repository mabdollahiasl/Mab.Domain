﻿
using Mab.Domain.Base.Entities;
using Mab.Domain.Base.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test
{
    public class Person : EntityBase<int>,IAggregateRoot
    {
       

        public string Name { get; set; }
        public int Age { get; set; }
        public Teacher Teacher { get; set; }
    }
}
