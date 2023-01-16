using AudioShare.Core.Entities;
using MediatR;
namespace AudioShare.Application.Commands
{
    public class DeleteAudioFile : IRequest<AudioFile>
    {
        public int Id { get; set; }
    }
}
