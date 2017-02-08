using System.ComponentModel.DataAnnotations;

namespace Amelia.WebApp.ViewModels
{
    public class NewProjectFormModel
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }
        public string Description { get; set; }
        public bool IsPrivate { get; set; }
        public short ProjectType { get; set; }
        public int OwnerId{get;set;}
    }
}