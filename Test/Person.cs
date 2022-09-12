using Mab.Domain.Base.Entities;
using Mab.Domain.Base.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test
{
    public class Person:EntityBase,IAggregateRoot
    {
        public Person(string name, int age)
        {
            Name = name;
            Age = age;
        }

        public string Name { get; set; }    
        public int Age { get; set; }    
    }
}
