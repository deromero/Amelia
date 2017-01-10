using System;
using System.Collections.Generic;

namespace Amelia.Domain.Models
{
    public class Comment : IEntityBase
    {
        public int Id { get; set; }
        public string Content { get; set; }
        public Member CreatedBy { get; set; }
        public Member UpdatedBy { get; set; }
        public DateTime CreatedOn { get; set; }
        public DateTime UpdatedOn { get; set; }

        public bool IsPrivate { get; set; }
        public bool IsResolved { get; set; }
        public Task Task { get; set; }

        public virtual IEnumerable<Attachment> Attachments { get; set; }

    }
}