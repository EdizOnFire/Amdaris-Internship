using System;

namespace AudioShare.Core.Entities
{
    public class Comment : BaseEntity
    {
        public string Owner { get; set; } = null!;
        public string Content { get; set; } = null!;
    }
}
