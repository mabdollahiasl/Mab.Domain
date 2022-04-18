using Mab.Blogs.Domain.Entities.Groups;
using Mab.Blogs.Domain.Entities.Keywords;
using Mab.Domain.Base.Entities;
using Mab.Domain.Base.Interfaces;

namespace Mab.Blogs.Domain.Entities.BlogPosts

{
    public class BlogPost:EntityBase<int>, IAggregateRoot
    {
        private readonly HashSet<Keyword> _keyWords;
        public IReadOnlyCollection<Keyword> Keywords => _keyWords;

        private readonly HashSet<Group> _groups;
        public IReadOnlyCollection<Group> Groups => _groups;

        public string Title { get; private set; }
        public string Description { get; private set; }
        public string Content { get; private set; }
        public string Name { get; private set; }
        public Guid CreatorId { get; set; }
        public Guid LastEditorId { get; set; }
        public DateTimeOffset RegDate { get; private set; }


        private BlogPost()
        {

        }

        public BlogPost(string title,
                        string description,
                        string content,
                        string name,
                        Guid creatorId,
                        Guid lastEditorId)
        {
            _groups = new HashSet<Group>();
            _keyWords = new HashSet<Keyword>();
            RegDate = DateTimeOffset.Now;
            Update(title, description, content, name, creatorId, lastEditorId);
        }

        public void Update(string title,
                       string description,
                       string content,
                       string name,
                       Guid creatorId,
                       Guid lastEditorId)
        {
            Title = title;
            Description = description;
            Content = content;
            Name = name;
            CreatorId = creatorId;
            LastEditorId = lastEditorId;
        }
        public void AddKeyword(Keyword keyword)
        {
            _keyWords.Add(keyword);
        }
        public void AddGroup(Group group)
        {
            _groups.Add(group);
        }
    }
}