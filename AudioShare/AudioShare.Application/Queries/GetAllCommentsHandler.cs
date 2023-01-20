using AudioShare.Application.Abstract;
using AudioShare.Core.Entities;
using MediatR;

namespace AudioShare.Application.Queries
{
    public class GetAllCommentsHandler : IRequestHandler<GetAllComments, List<Comment>>
    {
        private readonly IUnitOfWork _unitOfWork;
        public GetAllCommentsHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<List<Comment>> Handle(GetAllComments request, CancellationToken cancellationToken)
        {
            return await _unitOfWork.CommentRepository.GetAll();
        }
    }
}
