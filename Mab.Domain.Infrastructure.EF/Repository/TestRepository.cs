using Mab.Domain.Infrastructure.EF.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using Mab.Domain.Base.QueryBuilder;
using Mab.Blogs.Domain.Model;

namespace Mab.Domain.Infrastructure.EF.Repository
{
    internal class TestRepository
    {
        private BlogContext _db;
        void test()
        {
            Query<BlogPost> query = new Query<BlogPost>();
            _db = new BlogContext();

            var inc= query.Include(a => a.Groups).ThenInclude(v=>v.Title);


           // var outi = _db.BlogPosts.Include(a => a.Groups).ThenInclude(inc);

          //  var outone = _db.BlogPosts.Include(a => a.LastEditor);

        }
    }
}
