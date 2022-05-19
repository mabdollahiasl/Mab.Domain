using Mab.Domain.Base.Entities;
using Mab.Domain.Base.Interfaces;
using Mab.Domain.Base.Validation;

namespace Mab.Blogs.Domain.Entities.Keywords
{
    public class Keyword : EntityBase<int>, IAggregateRoot
    {
        public string Title { get; private set; }

        private Keyword()
        {
        }
        public Keyword(string title)
        {
            Create(title);
        }
        private void Create(string title)
        {
            Validation.Throw.OnNullOrEmpty(title, nameof(title));
            Title = title;
        }
        public void Update(string title)
        {
            Title = title;
        }
    }
}