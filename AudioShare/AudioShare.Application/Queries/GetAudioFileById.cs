using AudioShare.Core.Entities;
using MediatR;
using System.Numerics;

namespace AudioShare.Application.Queries
{
    public class GetAudioFileById : IRequest<AudioFile>
    {
        public int Id { get; set; }
    }
}
