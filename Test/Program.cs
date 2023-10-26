

using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Mab.Domain.Infrastructure.EF;
using Test;
using Test.Data;
using Microsoft.EntityFrameworkCore;
using Mab.Domain.Base.Interfaces;
using Test.CustomQuery;
using Mab.Domain.Base;

using IHost host = Host.CreateDefaultBuilder(args)
    .ConfigureServices(services =>
    {
        services.AddInfrastructureBase();
        services.AddDbContext<TestContext>((opt) => opt.UseInMemoryDatabase("TestData"));
        services.AddScoped(typeof(IReadRepositoryBase<>), typeof(EFRepository<>));
        services.AddScoped(typeof(IWriteRepositoryBase<>), typeof(EFRepository<>));
        services.AddScoped(typeof(IRepositoryBase<>), typeof(EFRepository<>));
    })
    .Build();
using IServiceScope serviceScope = host.Services.CreateScope();
IServiceProvider provider = serviceScope.ServiceProvider;

IRepositoryBase<Person> _repository = provider.GetService<IRepositoryBase<Person>>();
if (_repository == null)
{
    return;
}

await _repository.Add(new Person { Name = "N1", Age = 1, Id = 4 });
await _repository.Add(new Person { Name = "N2", Age = 1, Id = 2 });
await _repository.Add(new Person { Name = "N3", Age = 2, Id = 3 });
await _repository.Add(new Person { Name = "N4", Age = 2, Id = 1 });

await _repository.UnitOfWork.SaveChanges();

IQueryable<Person> ss;

//var person= await _repository.GetAllByQuery(new PersonGroupByAgeQuery());

var persons = await _repository.GetAllByQuery(new PersonGroupByAgeQuery());

Console.WriteLine();


await host.RunAsync();



public class TestRepository
{
    IReadRepositoryBase<Person> _readRepository;

    public TestRepository(IReadRepositoryBase<Person> readRepository)
    {
        _readRepository = readRepository;
    }


}