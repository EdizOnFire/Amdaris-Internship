using AudioShare.Application.Abstract;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AudioShare.Core.Entities;
using System.Numerics;

namespace AudioShare.Application.Commands
{
    public class CreateCommentHandler : IRequestHandler<CreateComment, Comment>
    {
        private readonly IUnitOfWork _unitOfWork;
        public CreateCommentHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<Comment> Handle(CreateComment request, CancellationToken cancellationToken)
        {
            var comment = new Comment
            {
                Owner = request.Owner,
                Content = request.Content
            };

            await _unitOfWork.CommentRepository.Add(comment);
            await _unitOfWork.SaveAsync();

            return comment;
        }
    }
}