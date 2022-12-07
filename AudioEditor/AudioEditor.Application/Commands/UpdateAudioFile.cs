using MediatR;
using AudioEditor.Core.Entities;

namespace AudioEditor.Application.Commands
{
    public class UpdateAudioFile : IRequest<AudioFile>
    {
        public int Id { get; set; }
        public string FileName { get; set; } = null!;
        public string Format { get; set; } = null!;
        public int UserId { get; set; }
        public DateTime CreatedDate { get; }
        public DateTime ModifiedDate { get; set; }
    }
}
