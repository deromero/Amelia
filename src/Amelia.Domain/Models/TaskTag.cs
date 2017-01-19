namespace Amelia.Domain.Models
{
    public class TaskTag : IEntityBase{
        public int Id{get;set;}
        public Task Task{get;set;}
        public Tag Tag{get;set;}
    }
}