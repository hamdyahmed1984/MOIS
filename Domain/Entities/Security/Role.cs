using System.Collections.Generic;

namespace Domain.Entities.Security
{
    public class Role : BaseEntity
    {
        public string Name { get; set; }
        public IList<UserRole> UsersRole { get; set; } = new List<UserRole>();
    }
}
