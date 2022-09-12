

using Mab.Domain.Base.Interfaces;
using Mab.Domain.Base.QueryBuilder;
using Mab.Domain.Infrastructure.EF;
using Mab.Domain.Infrastructure.EF.Repository;
using Test;

PersonAgeBiggerThanTen query = new PersonAgeBiggerThanTen();




EfRepo Ef=new EfRepo(null);

var res=Ef.Get(new PersonAgeBiggerThanTen());



Console.WriteLine("Hello, World!");

public class PersonAgeBiggerThanTen : QueryBuilder<Person>
{
    public PersonAgeBiggerThanTen()
    {
        Query.Where(a => a.Age > 10).OrderByDescending(a => a.Age);
    }
}
public class EfRepo : RepositoryBase<Person>
{
    public EfRepo(DbContextBase dbContext) : base(dbContext)
    {
    }
}