using Mab.Domain.Base.QueryBuilder;
using Mab.Domain.Base.QueryBuilder.CustomQuery;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test.CustomQuery
{
    [QueryResolverOf(typeof(PersonGroupByAgeQuery))]
    public class QueryApplier : ICustomQueryApplier<Person, PersonAgeWithCount>
    {
        public IQueryable<PersonAgeWithCount> Apply(IQueryable<Person> entities, ICustomQuery<Person, PersonAgeWithCount> query)
        {
            
            return entities.GroupBy(p => p.Age).Select(g => new PersonAgeWithCount(g.Key, g.Count()));
        }
    }
}
