using AudioShare.Application.Abstract;
using AudioShare.Core.Entities;
using MediatR;
using System.Numerics;

namespace AudioShare.Application.Commands
{
    public class DeleteCommentHandler : IRequestHandler<DeleteComment, Comment>
    {
        private readonly IUnitOfWork _unitOfWork;

        public DeleteCommentHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<Comment> Handle(DeleteComment request, CancellationToken cancellationToken)
        {
            var comment = await _unitOfWork.CommentRepository.GetByOwner(request.Owner);

            _unitOfWork.CommentRepository.Remove(comment);

            await _unitOfWork.SaveAsync();

            return comment;
        }
    }
}
