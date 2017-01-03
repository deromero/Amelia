using System;

namespace Amelia.WebApi.Models.Entities
{
    public class Project : IEntityBase
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string HomePage { get; set; }
        public int ParentId { get; set; }
        public int ProjectCount { get; set; }
        public DateTime CreatedOn { get; set; }
        public DateTime UpdatedOn { get; set; }
    }
}