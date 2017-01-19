using System;

namespace Amelia.Domain.Models
{
    public class Tag : IEntityBase
    {
        public int Id{get;set;}
        public string Name {get;set;}
        public DateTime CreatedOn{get;set;}
        public Project Project{get;set;}
    }
}