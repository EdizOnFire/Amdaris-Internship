using AudioEditor.Core.Entities;
using MediatR;

namespace AudioEditor.Application.Queries
{
    public class GetAllAudioFiles : IRequest<List<AudioFile>>
    {
    }
}
