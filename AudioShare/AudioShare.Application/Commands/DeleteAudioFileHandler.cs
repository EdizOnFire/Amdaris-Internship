using AudioShare.Application.Abstract;
using AudioShare.Core.Entities;
using MediatR;
using System.Numerics;

namespace AudioShare.Application.Commands
{
    public class DeleteAudioFileHandler : IRequestHandler<DeleteAudioFile, AudioFile>
    {
        private readonly IUnitOfWork _unitOfWork;

        public DeleteAudioFileHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<AudioFile> Handle(DeleteAudioFile request, CancellationToken cancellationToken)
        {
            var audioFile = await _unitOfWork.AudioFileRepository.GetById(request.Id);

            _unitOfWork.AudioFileRepository.Remove(audioFile);

            await _unitOfWork.SaveAsync();

            return audioFile;
        }
    }
}
