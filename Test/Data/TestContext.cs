using Mab.Domain.Infrastructure.EF;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace Test.Data
{
    public class TestContext: DbContextBase
    {
        public DbSet<Person> Persons { get; set; }
        public DbSet<Teacher> Teachers { get; set; }
        public DbSet<Room> Rooms { get; set; }

        public TestContext(DbContextOptions<TestContext> options)
         : base(options)
        {
        }
        public TestContext()
        {

        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //optionsBuilder.UseSqlServer(@"***REMOVED***");
            base.OnConfiguring(optionsBuilder);
        }
    }
}
