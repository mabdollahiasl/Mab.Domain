using Mab.Domain.Base.Entities;
using Mab.Domain.Base.Interfaces;

namespace Mab.Blogs.Domain.Entities.Groups
{
    public class Group : EntityBase<int>, IAggregateRoot
    {
        public string Title { get; private set; }
        public string Description { get; private set; }

        private Group()
        {

        }
        public Group(string title, string description)
        {
           Update(title, description);
        }
    

        public void Update(string title, string description)
        {
            Title = title;
            Description = description;
        }

    }
}