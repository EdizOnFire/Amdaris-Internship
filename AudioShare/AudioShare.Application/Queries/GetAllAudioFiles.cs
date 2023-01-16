using AudioShare.Core.Entities;
using MediatR;

namespace AudioShare.Application.Queries
{
    public class GetAllAudioFiles : IRequest<List<AudioFile>>
    {
    }
}
