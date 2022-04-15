using Mab.Blogs.Domain.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mab.Domain.Infrastructure.EF.Data
{
    public class BlogContext:DbContext
    {
      public  DbSet<Keyword> Keywords { get; }
        public DbSet<BlogPost> BlogPosts { get; }

    }
}
