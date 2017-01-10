using System;

namespace Amelia.Domain.Models
{
    public class ProjectRole : IEntityBase
    {
        public int Id{get;set;}
        public string Name{get;set;}

        public Project Project{get;set;}

        public DateTime CreatedOn{get;set;}        
    }
}