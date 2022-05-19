using Mab.Blogs.Domain.Entities.Groups;
using Mab.Blogs.Domain.Entities.Keywords;
using Mab.Domain.Base.Entities;
using Mab.Domain.Base.Interfaces;
using Mab.Domain.Base.Validation;

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
        public Guid WriterId { get; set; }
        public Guid? LastEditorId { get; set; }
        public DateTimeOffset RegDate { get; private set; }


        private BlogPost()
        {
            //for entity framework
        }

        public BlogPost(string title,
                        string description,
                        string content,
                        string name,
                        Guid writerId)
        {
            _groups = new HashSet<Group>();
            _keyWords = new HashSet<Keyword>();
            Create(title, description, content, name,writerId);
        }

        private void Create(string title,
                            string description,
                            string content,
                            string name,
                            Guid writerID)
        {
            Validation.Throw.OnNullOrEmpty(title, nameof(title));
            Validation.Throw.OnNullOrEmpty(content, nameof(content));
            Validation.Throw.OnNullOrEmpty(name, nameof(name));
            RegDate = DateTimeOffset.Now;
            Title = title;
            Description = description;
            Content = content;
            Name = name;
            WriterId = writerID;
        }

        public void Update(string title,
                       string description,
                       string content,
                       string name,
                       Guid? lastEditorId)
        {
            Validation.Throw.OnNullOrEmpty(title,nameof(title));
            Validation.Throw.OnNullOrEmpty(content, nameof(content));
            Validation.Throw.OnNullOrEmpty(name, nameof(name));
            Validation.Throw.OnNull(lastEditorId, nameof(lastEditorId));

            Title = title;
            Description = description;
            Content = content;
            Name = name;
            LastEditorId = lastEditorId;
        }
        public void AddKeyword(Keyword keyword)
        {
            Validation.Throw.OnNull(keyword, nameof(keyword));
            _keyWords.Add(keyword);
        }
        public void AddGroup(Group group)
        {
            Validation.Throw.OnNull(group, nameof(group));
            _groups.Add(group);
        }
    }
}