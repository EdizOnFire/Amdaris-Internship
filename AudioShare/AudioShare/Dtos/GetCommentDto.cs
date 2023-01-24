using AudioShare.Core.Entities;
using System.ComponentModel.DataAnnotations;

namespace AudioShare.API.Dtos
{
    public class GetCommentDto
    {
        public int Id { get; set; }
        public string Owner { get; set; } = null!;
        public string Content { get; set; } = null!;
        public int AudioFileId { get; set; }
    }
}
