using System;

namespace Amelia.WebApi.Models.Entities
{
    public class User : IEntityBase
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public bool EmailNotification { get; set; }
        public bool IsAdmin { get; set; }
        public int Status { get; set; }
        public string Language { get; set; }
        public DateTime LastLoginOn { get; set; }
        public DateTime CreatedOn { get; set; }
        public DateTime UpdatedOn { get; set; }
        public int AuthSourceId { get; set; }
    }
}



