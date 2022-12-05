using System;

namespace AudioEditor.Core.Models
{
    public class User : BaseEntity
    {
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? Email { get; set; }
        public List<AudioFile>? AudioFiles { get; set; }
    }
}
