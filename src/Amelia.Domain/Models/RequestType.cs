using System.Collections.Generic;

namespace Amelia.Domain.Models
{
    public class RequestType : IEntityBase
    {
        public int Id{get;set;}
        public string Name{get;set;}
        public string Description{get;set;}

        public Project Project{get;set;}
        public virtual IEnumerable<Task> Tasks{get;set;}
    }
}