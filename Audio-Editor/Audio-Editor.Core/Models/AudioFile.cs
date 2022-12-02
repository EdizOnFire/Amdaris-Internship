using System;

namespace AudioEditor.Core.Models
{
    public class AudioFile : BaseEntity
    {
        public string? FileName
        {
            get;
            set;
        }
        public string? Format
        {
            get;
            set;
        }
    }
}
