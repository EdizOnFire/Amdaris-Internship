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
        public string Path { get; set; } = null!;
        public DateTime LastModified { get; set; }
    }
}
