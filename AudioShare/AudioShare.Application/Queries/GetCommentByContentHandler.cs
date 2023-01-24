using AudioShare.Application.Abstract;
using AudioShare.Core.Entities;
using MediatR;
using System.Numerics;

namespace AudioShare.Application.Queries
{
    public class GetCommentByIdHandler : IRequestHandler<GetCommentById, Comment>
    {
        private readonly IUnitOfWork _unitOfWork;

        public GetCommentByIdHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<Comment> Handle(GetCommentById request, CancellationToken cancellationToken)
        {
            return await _unitOfWork.CommentRepository.GetById( request.Id);
        }
    }
}
