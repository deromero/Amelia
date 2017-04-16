using System;

namespace Amelia.WebApp.ViewModels
{
    public class TaskViewModel
    {
        public int Id { get; set; }
        public string Subject { get; set; }
        public string Description { get; set; }
        public int Status { get; set; }
        public DateTime CreatedOn { get; set; }
        public int ProjectId { get; set; }
        public int SprintId { get; set; }
        public int TaskTypeId { get; set; }
        public int RequestTypeId { get; set; }
        public int AssignedToId { get; set; }
        public string AssignedToName { get; set; }
        public int Points { get; set; }
    }
}