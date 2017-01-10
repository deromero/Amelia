namespace Amelia.Domain.Models
{
    public class TaskStatus : IEntityBase
    {
        public int Id {get;set;}
        public string Name{get;set;}
        public string Slug{get;set;}
        public bool IsClosed{get;set;}
        public bool IsArchived{get;set;}
        public int WipLimit{get;set;}
        public string Color{get;set;}

        public Module Module{get;set;}
        public Project Project{get;set;}
        public TaskType TaskType{get;set;}

    }
}