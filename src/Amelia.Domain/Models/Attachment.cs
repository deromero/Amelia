using System;

namespace Amelia.Domain.Models
{
    public class Attachment : IEntityBase
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string FileName { get; set; }
        public string Extension { get; set; }
        public int Size { get; set; }
        public string MimmeType { get; set; }
        public string FilePath { get; set; }
        public DateTime CreatedOn { get; set; }
        public Member CreatedBy{get;set;}

    }
}