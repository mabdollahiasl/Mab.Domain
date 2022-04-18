using Mab.Blogs.Domain.Entities.Groups;
using Mab.Blogs.Domain.Entities.Keywords;
using Mab.Domain.Base.Entities;
using Mab.Domain.Base.Interfaces;

namespace Mab.Blogs.Domain.Entities.Datafiles
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
        public Guid CreatorId { get; set; }

        public DataFile(string name,
                        string type,
                        int size,
                        string hash,
                        Guid creatorId)
        {
            _keyWords = new List<Keyword>();
            _groups = new List<Group>();
            Update(name, type, size, hash, creatorId);
        }
        public void Update(string name,
                        string type,
                        int size,
                        string hash,
                        Guid creatorId)
        {
            Name = name;
            Type = type;
            Size = size;
            Hash = hash;
            CreatorId = creatorId;
        }
    }
}