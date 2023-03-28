using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test.CustomQuery
{
    public class PersonAgeWithCount
    {
        public PersonAgeWithCount(int age, int count)
        {
            Age = age;
            Count = count;
        }

        public int Age { get; set; }
        public int Count { get; set; }
    }
}
