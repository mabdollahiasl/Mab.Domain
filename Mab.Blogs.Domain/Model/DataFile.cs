using Mab.Domain.Base.Interfaces;
using Mab.Domain.Base.Model;

namespace Mab.Blogs.Domain.Model
{
    public class DataFile : EntityBase<int>, IAggregateRoot
    {
        private IReadOnlyCollection<Group> _groups;
        private IReadOnlyCollection<Keyword> _keyWords;

        public IReadOnlyCollection<Keyword> Keywords => _keyWords;
        public IReadOnlyCollection<Group> Groups => _groups;
        public string Name { get; private set; }
        public string Type { get; private set; }
        public int Size { get; private set; }
        public string Hash { get; private set; }

        public User Creator { get; set; }
    }
}