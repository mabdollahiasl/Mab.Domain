using Mab.Domain.Base.Interfaces;
using Mab.Domain.Base.Model;

namespace Mab.Blogs.Domain.Model
{
    public class BlogPost:EntityBase<int>, IAggregateRoot
    {
        private IReadOnlyCollection<Keyword> _keyWords;
        public IReadOnlyCollection<Keyword> Keywords => _keyWords;
       
        private IReadOnlyCollection<Group> _groups;
        public IReadOnlyCollection<Group> Groups => _groups;

        public string Title { get; private set; }
        public string Description { get; private set; }
        public string Content { get; private set; }
        public string Name { get; private set; }

        public User Creator { get; set; }
        public User LastEditor { get; set; }
        public DateTimeOffset RegDate { get; private set; }


        private BlogPost()
        {

        }

    }
}