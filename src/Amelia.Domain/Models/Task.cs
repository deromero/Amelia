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
        public Member CreatedBy{get;set;}
        public Member AssignedTo{get;set;}
        public Task ParentTask{get;set;}

        public RequestType RequestType {get;set;}

        public virtual IEnumerable<Task> ChildTasks{get;set;}
        public virtual IEnumerable<Task> RelatedTasks{get;set;}
        public virtual IEnumerable<Tag> Tags{get;set;}
        public virtual IEnumerable<Comment> Comments{get;set;}
        public virtual IEnumerable<Attachment> Attachments{get;set;}
        public virtual IEnumerable<Point> Points{get;set;}
    }
}