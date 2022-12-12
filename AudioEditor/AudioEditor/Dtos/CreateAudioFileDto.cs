using System.ComponentModel.DataAnnotations;

namespace AudioEditor.API.Dtos
{
    public class CreateAudioFileDto
    {
        [Key]
        public int Id { get; set; }
        public string FileName { get; set; } = null!;
        public string Format { get; set; } = null!;
        public int UserId { get; set; }
        public string Path { get; set; } = null!;
        public DateTime LastModified { get; set; }
    }
}
