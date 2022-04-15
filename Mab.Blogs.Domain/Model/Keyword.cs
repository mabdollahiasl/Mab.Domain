using Mab.Domain.Base.Interfaces;
using Mab.Domain.Base.Model;

namespace Mab.Blogs.Domain.Model
{
    public class Keyword : EntityBase<int>, IAggregateRoot
    {
        public string Title { get; set; }
    }
}