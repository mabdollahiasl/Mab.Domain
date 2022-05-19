using Mab.Domain.Base.Entities;
using Mab.Domain.Base.Interfaces;
using Mab.Domain.Base.Validation;

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
           Create(title, description);
        }


        public void Create(string title, string description)
        {
            Validation.Throw.OnNullOrEmpty(title, nameof(title));
            Title = title;
            Description = description;
        }
        public void Update(string title, string description)
        {
            Validation.Throw.OnNullOrEmpty(title, nameof(title));
            Title = title;
            Description = description;
        }

    }
}