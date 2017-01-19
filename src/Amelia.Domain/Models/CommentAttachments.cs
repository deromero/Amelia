using System;

namespace Amelia.Domain.Models
{
    public class CommentAttachment : IEntityBase
    {
        public int Id { get; set; }
        public Comment Comment{get;set;}
        public Attachment Attachment{get;set;}
    }
}

