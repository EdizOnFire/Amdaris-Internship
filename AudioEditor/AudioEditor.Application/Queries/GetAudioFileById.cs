using AudioEditor.Core.Entities;
using MediatR;
using System.Numerics;

namespace AudioEditor.Application.Queries
{
    public class GetAudioFileById : IRequest<AudioFile>
    {
        public int Id { get; set; }
    }
}
