

using Mab.Blogs.Domain.Entities.BlogPosts;
using Mab.Domain.Base.QueryBuilder;
using Test;

PersonAgeBiggerThanTen query = new PersonAgeBiggerThanTen();

List<Person> people = new();
people.Add(new Person("Sepehr", 5));
people.Add(new Person("Nima", 8));
people.Add(new Person("Ava", 12));
people.Add(new Person("Ida", 25));


var res = query.Apply(people.AsQueryable<Person>());



Console.WriteLine("Hello, World!");

public class PersonAgeBiggerThanTen : QueryBuilder<Person>
{
    public PersonAgeBiggerThanTen()
    {
        Query.Where(a => a.Age > 10).OrderByDescending(a => a.Age);
    }
}