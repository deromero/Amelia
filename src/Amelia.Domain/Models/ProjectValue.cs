namespace Amelia.Domain.Models
{
    public class ProjectValue : IEntityBase
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Color { get; set; }
        public decimal Value { get; set; }
        public short Position { get; set; }
        public Project Project { get; set; }
        public ProjectValueType ValueType{get;set;}

    }
}