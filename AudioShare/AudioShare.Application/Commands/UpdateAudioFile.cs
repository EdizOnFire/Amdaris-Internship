using MediatR;
using AudioShare.Core.Entities;

namespace AudioShare.Application.Commands
{
    public class UpdateAudioFile : IRequest<AudioFile>
    {
        public string FileName { get; set; } = null!;
        public string Format { get; set; } = null!;
        public string Title { get; set; } = null!;
        public string Description { get; set; } = null!;
        public string Path { get; set; } = null!;
        public int User { get; set; }
        public string[] Comments { get; set; } = null!;
    }
}
