using System;

namespace Amelia.WebApp.ViewModels
{
    public class ProjectViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Slug { get; set; }
        public string ImageLogoUrl { get; set; }
        public bool IsPrivate { get; set; }
        public short ProjectType { get; set; }
        public DateTime CreatedOn { get; set; }
        public DateTime UpdatedOn { get; set; }

        public string OnwerName{get;set;}
        public int OwnerId{get;set;}
        public int IssueCount { get; set; }
    }
}