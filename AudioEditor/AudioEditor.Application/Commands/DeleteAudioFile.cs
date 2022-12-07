using AudioEditor.Core.Entities;
using MediatR;
namespace AudioEditor.Application.Commands
{
    public class DeleteAudioFile : IRequest<AudioFile>
    {
        public int Id { get; set; }
    }
}
