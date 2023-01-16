using AudioShare.Application.Abstract;
using AudioShare.Core.Entities;
using MediatR;

namespace AudioShare.Application.Commands
{
    public class UpdateAudioFileHandler : IRequestHandler<UpdateAudioFile, AudioFile>
    {
        private readonly IUnitOfWork _unitOfWork;
        public UpdateAudioFileHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task<AudioFile> Handle(UpdateAudioFile request, CancellationToken cancellationToken)
        {
            var audioFile = new AudioFile
            {
                FileName = request.FileName,
                Format = request.Format,
                Title = request.Title,
                Description = request.Description,
                User = request.User,
                Path = request.Path,
            };

            await _unitOfWork.AudioFileRepository.Update(audioFile);
            await _unitOfWork.SaveAsync();

            return audioFile;
        }
    }
}