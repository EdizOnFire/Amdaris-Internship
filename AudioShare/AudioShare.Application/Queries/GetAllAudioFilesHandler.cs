using AudioShare.Application.Abstract;
using AudioShare.Core.Entities;
using MediatR;

namespace AudioShare.Application.Queries
{
    public class GetAllAudioFilesHandler : IRequestHandler<GetAllAudioFiles, List<AudioFile>>
    {
        private readonly IUnitOfWork _unitOfWork;
        public GetAllAudioFilesHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<List<AudioFile>> Handle(GetAllAudioFiles request, CancellationToken cancellationToken)
        {
            return await _unitOfWork.AudioFileRepository.GetAll();
        }
    }
}
