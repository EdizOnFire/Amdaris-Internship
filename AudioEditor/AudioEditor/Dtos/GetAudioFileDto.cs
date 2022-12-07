using System.ComponentModel.DataAnnotations;

namespace AudioEditor.API.Dtos
{
    public class GetAudioFileDto
    {
        public int Id { get; set; }
        public string FileName { get; set; } = null!;
        public string Format { get; set; } = null!;
        public int UserId { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime ModifiedDate { get; set; }
    }
}
