using System.ComponentModel.DataAnnotations;

namespace AudioEditor.API.Dtos
{
    public class GetAudioFileDto
    {
        public int Id { get; set; }
        public string FileName { get; set; } = null!;
        public string Format { get; set; } = null!;
        public int UserId { get; set; }
        public string Path { get; set; } = null!;
        public DateTime LastModified { get; set; }
    }
}
