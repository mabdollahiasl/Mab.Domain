using Mab.Domain.Base.QueryBuilder;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test
{
    public class SortQuery:QueryBuilder<Person>
    {
        public SortQuery(string propertName)
        {
            Query.Include(p=>p.Teacher.Rooms).ThenInclude(a=>a.Base).OrderBy(propertName);
        }
    }
}
