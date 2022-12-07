using System;

namespace AudioEditor.Core.Entities
{
    public class AudioFile : BaseEntity
    {
        public string FileName { get; set; } = null!;
        public string Format { get; set; } = null!;
        public int UserId { get; set; }
    }
}
