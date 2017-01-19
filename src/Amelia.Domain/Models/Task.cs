using System;
using System.Collections.Generic;

namespace Amelia.Domain.Models
{
    public class Task : IEntityBase
    {
        public int Id { get; set; }
        public string Subject { get; set; }
        public string Description { get; set; }
        public int Status { get; set; }
        public DateTime CreatedOn{get;set;}
        public Project Project{get;set;}
        public Sprint Sprint{get;set;}
        public TaskType TaskType{get;set;}
        public RequestType RequestType {get;set;}
        
        public Member CreatedBy{get;set;}
        public Member AssignedTo{get;set;}
        public int? ParentId{get;set;}
        public virtual Task Parent{get;set;}
        public virtual IEnumerable<Task> Children{get;set;}
        public virtual IEnumerable<TaskTag> Tags{get;set;}
        public virtual IEnumerable<Comment> Comments{get;set;}
        public virtual IEnumerable<Point> Points{get;set;}
    }
}