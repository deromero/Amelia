using System;
using System.Collections.Generic;

namespace Amelia.Domain.Models
{
    public class Project : IEntityBase
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Slug{get;set;}
        public string ImageLogoUrl { get; set; }
        public bool IsPrivate { get; set; }
        public short Status { get; set; }
        public short ProjectType { get; set; }
        public DateTime CreatedOn { get; set; }
        public DateTime UpdatedOn { get; set; }
        public User Owner { get; set; }

        public virtual IEnumerable<Module> Modules {get;set;}
        public virtual IEnumerable<Role> Roles{get;set;}
    
    }
}