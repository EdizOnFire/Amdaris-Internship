using AudioEditor.Application.Abstract;
using AudioEditor.Core.Entities;
using MediatR;

namespace AudioEditor.Application.Commands
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
                Id = request.Id,
                FileName = request.FileName,
                Format = request.Format,
                UserId = request.UserId,
                ModifiedDate = DateTime.Now
            };

            await _unitOfWork.AudioFileRepository.Update(audioFile);
            await _unitOfWork.SaveAsync();

            return audioFile;
        }
    }
}