using System;
using System.Collections.Generic;

namespace Amelia.Domain.Models
{
    public class User : IEntityBase
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string Salt { get; set; }
        public string Email { get; set; }
        public short Status { get; set; }
        public DateTime CreatedOn { get; set; }

        public virtual ICollection<UserRole> UserRoles { get; set; }

        public User()
        {
            UserRoles = new List<UserRole>();
        }
    }
}