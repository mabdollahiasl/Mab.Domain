using Mab.Domain.Base.QueryBuilder;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test.CustomQuery
{
    public class PersonGroupByAgeQuery:CustomQuery<Person,PersonAgeWithCount>
    {
        public override IQueryable<PersonAgeWithCount> Query(IQueryable<Person> query)
        {
           return query.GroupBy(a => a.Age).
                        Select(a => new PersonAgeWithCount(a.Key, a.Count()));
        }
    }
}
