namespace Amelia.Domain.Models
{
    public class TaskType : IEntityBase
    {
        public int Id{get;set;}
        public string Name{get;set;}
        public string Description{get;set;}
    }
}