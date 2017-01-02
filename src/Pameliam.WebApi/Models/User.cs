using System;

namespace Pameliam.Models
{
    public class User
    {
        public string Login { get; set; }
        public string HashedPassword { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Mail { get; set; }
        public bool MailNotification { get; set; }
        public bool IsAdmin { get; set; }
        public int Status { get; set; }
        public string Language { get; set; }
        public DateTime LastLoginOn { get; set; }
        public DateTime CreatedOn { get; set; }
        public DateTime UpdatedOn { get; set; }
        public int AuthSourceId { get; set; }
    }
}



