using AudioShare.Application.Abstract;
using AudioShare.Core.Entities;
using MediatR;
using System.Numerics;

namespace AudioShare.Application.Queries
{
    public class GetCommentByOwnerHandler : IRequestHandler<GetCommentByOwner, Comment>
    {
        private readonly IUnitOfWork _unitOfWork;

        public GetCommentByOwnerHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<Comment> Handle(GetCommentByOwner request, CancellationToken cancellationToken)
        {
            return await _unitOfWork.CommentRepository.GetByOwner(request.Owner);
        }
    }
}
