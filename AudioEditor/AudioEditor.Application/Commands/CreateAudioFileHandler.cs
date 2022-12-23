using AudioEditor.Application.Abstract;
using AudioEditor.Core.Entities;
using MediatR;

namespace AudioEditor.Application.Commands
{
    public class CreateAudioFileHandler : IRequestHandler<CreateAudioFile, AudioFile>
    {
        private readonly IUnitOfWork _unitOfWork;
        public CreateAudioFileHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task<AudioFile> Handle(CreateAudioFile request, CancellationToken cancellationToken)
        {
            var audioFile = new AudioFile
            {
                Id = request.Id,
                FileName = request.FileName,
                Format = request.Format,
                UserId = request.UserId,
                Path = request.Path,
                LastModified = DateTime.Now
            };

            await _unitOfWork.AudioFileRepository.Add(audioFile);
            await _unitOfWork.SaveAsync();

            return audioFile;
        }
    }

}
