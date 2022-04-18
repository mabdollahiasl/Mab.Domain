using Mab.Domain.Base.Entities;
using Mab.Domain.Base.Interfaces;

namespace Mab.Blogs.Domain.Entities.Keywords
{
    public class Keyword : EntityBase<int>, IAggregateRoot
    {
      

        public string Title { get; private set; }

        public Keyword(string title)
        {
            Update(title);
        }

        public void Update(string title)
        {
            Title = title;
        }
    }
}