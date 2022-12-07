using AudioEditor.Application.Abstract;
using AudioEditor.Core.Entities;
using MediatR;
using System.Numerics;

namespace AudioEditor.Application.Queries
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
            return await this._unitOfWork.AudioFileRepository.GetById(request.Id);
        }
    }
}
