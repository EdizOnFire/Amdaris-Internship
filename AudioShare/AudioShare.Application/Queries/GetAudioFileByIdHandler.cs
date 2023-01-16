using AudioShare.Application.Abstract;
using AudioShare.Core.Entities;
using MediatR;
using System.Numerics;

namespace AudioShare.Application.Queries
{
    public class GetAudioFileByIdHandler : IRequestHandler<GetAudioFileById, AudioFile>
    {
        private readonly IUnitOfWork _unitOfWork;

        public GetAudioFileByIdHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<AudioFile> Handle(GetAudioFileById request, CancellationToken cancellationToken)
        {
            return await _unitOfWork.AudioFileRepository.GetById(request.Id);
        }
    }
}
