using System.Collections.Generic;

namespace Domain.Entities.Security
{
    public class User : BaseEntity
    {
        public string Email { get; set; }

        public string Password { get; set; }

        public IList<UserRole> UserRoles { get; set; } = new List<UserRole>();
    }
}
