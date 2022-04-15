using Mab.Blogs.Domain.Enums;
using Mab.Domain.Base.Interfaces;
using Mab.Domain.Base.Model;

namespace Mab.Blogs.Domain.Model
{
    public class User : EntityBase<int>, IAggregateRoot
    {
       
        public string Email { get; private set; }
        public string Password { get; private set; }
            
        public string UserName { get; private set; }

        public DateTimeOffset CreatedDate { get; private set; }

        public DateTimeOffset LastLoginTime { get; private set; }


    }
}
