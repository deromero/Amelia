namespace Amelia.Domain.Models
{
    public class Point : IEntityBase
    {
        public int Id{get;set;}
        public string Name{get;set;}
        public decimal Value{get;set;}
        public Project Project{get;set;}
    }
}