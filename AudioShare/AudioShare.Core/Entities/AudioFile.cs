using AudioShare.Core.Entities;
using System;

namespace AudioShare.Core.Entities
{
    public class AudioFile : BaseEntity
    {
        public string FileName { get; set; } = null!;
        public string Format { get; set; } = null!;
        public string Title { get; set; } = null!;
        public string Description { get; set; } = null!;
        public string Path { get; set; } = null!;
        public int User { get; set; }
        public List<string> Comments { get; set; } = new();
    }
}
