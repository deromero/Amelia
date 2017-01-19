namespace Amelia.Domain.Models
{
    public class TaskAttachment : IEntityBase
    {
        public int Id {get;set;}
        public Task Task{get;set;}
        public Attachment Attachment{get;set;}
        public int Position {get;set;}
        
    }
}