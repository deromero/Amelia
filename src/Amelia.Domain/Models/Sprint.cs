using System;
using System.Collections.Generic;

namespace Amelia.Domain.Models
{
    public class Sprint : IEntityBase
    {
        public int Id {get;set;}
        public string Name{get;set;}
        public string Description{get;set;}
        public DateTime StartDate{get;set;}
        public DateTime DueDate{get;set;}
        public DateTime CreatedOn{get;set;}
        public DateTime UpdatedOn{get;set;}
        public Project Project{get;set;} 

        public virtual IEnumerable<Task> Tasks{get;set;}
    }
}