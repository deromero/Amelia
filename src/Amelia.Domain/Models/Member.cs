namespace Amelia.Domain.Models
{
    public class Member : IEntityBase
    {
        public int Id {get;set;}
        public bool IsActive{get;set;}
        public bool IsAdmin{get;set;}
        public User User{get;set;}
        public ProjectRole Role{get;set;}
    }
}