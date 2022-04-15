using Mab.Blogs.Domain.Enums;
using Mab.Domain.Base.Interfaces;
using Mab.Domain.Base.Model;

namespace Mab.Blogs.Domain.Model
{
    public class UserRole : EntityBase<int>, IAggregateRoot
    {
        private IReadOnlyCollection<AccessType> _accessTypes;
        public IReadOnlyCollection<AccessType> AccessTypes => _accessTypes;
     
        public string Name { get; set; }
        
        
        public DateTimeOffset CreatedTime { get; set; }

    }
}
