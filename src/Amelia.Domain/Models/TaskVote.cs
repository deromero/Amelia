using System;

namespace Amelia.Domain.Models
{
    public class TaskVote : IEntityBase
    {
        public int Id { get; set; }
        public int Value { get; set; }
        public Member Member { get; set; }
        public ProjectRole ProjectRole { get; set; }
        public Point Point { get; set; }
        public Task Task { get; set; }
        public DateTime CreatedOn { get; set; }
        public DateTime UpdatedOn { get; set; }
    }
}