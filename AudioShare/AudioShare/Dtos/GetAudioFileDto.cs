using AudioShare.Core.Entities;
using System.ComponentModel.DataAnnotations;

namespace AudioShare.API.Dtos
{
    public class GetAudioFileDto
    {
        [Key]
        public int Id { get; set; }
        public string FileName { get; set; } = null!;
        public string Format { get; set; } = null!;
        public string Title { get; set; } = null!;
        public string Description { get; set; } = null!;
        public string Path { get; set; } = null!;
        public string User { get; set; } = null!;
        public List<Comment> Comments { get; set; } = new();
    }
}
