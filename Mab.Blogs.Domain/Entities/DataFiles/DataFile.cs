using Mab.Blogs.Domain.Entities.Groups;
using Mab.Blogs.Domain.Entities.Keywords;
using Mab.Domain.Base.Entities;
using Mab.Domain.Base.Interfaces;
using Mab.Domain.Base.Validation;

namespace Mab.Blogs.Domain.Entities.Datafiles
{
    public class DataFile : EntityBase<int>, IAggregateRoot
    {
        private IReadOnlyCollection<Group> _groups;
        private IReadOnlyCollection<Keyword> _keyWords;
        public IReadOnlyCollection<Keyword> Keywords => _keyWords;
        public IReadOnlyCollection<Group> Groups => _groups;
        public string Name { get; private set; }
        public string Title { get; private set; }

        public string Type { get; private set; }
        public int Size { get; private set; }
        public string Hash { get; private set; }
        public Guid CreatorId { get; set; }

        private DataFile()
        {

        }

        public DataFile(string title, string name,
                        string type,
                        int size,
                        string hash,
                        Guid creatorId)
        {
            _keyWords = new List<Keyword>();
            _groups = new List<Group>();
            Create(title, name, type, size, hash, creatorId);
        }
        private void Create(string title,
                            string name,
                            string type,
                            int size,
                            string hash,
                            Guid creatorID)
        {
            Validation.Throw.OnNullOrEmpty(name, nameof(name));
            Validation.Throw.OnNullOrEmpty(type, nameof(type));
            Validation.Throw.OnNullOrEmpty(hash, nameof(hash));
            Validation.Throw.OnNullOrEmpty(title, nameof(title));
            Validation.Throw.OnZeroAndSmaller(size, nameof(size));

            Title = title;
            CreatorId = creatorID;
            Name = name;
            Type = type;
            Size = size;
            Hash = hash;
        }
        public void Update(string title)
        {
            Validation.Throw.OnNullOrEmpty(title, nameof(title));
            Title = title;
        }
    }
}