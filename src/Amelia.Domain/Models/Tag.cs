using System;
using System.Collections.Generic;

namespace Amelia.Domain.Models
{
    public class Tag : IEntityBase
    {
        public int Id{get;set;}
        public string Name {get;set;}
        public DateTime CreatedOn{get;set;}
        public Project Project{get;set;}
        public IEnumerable<Task> Tasks{get;set;}
    }
}