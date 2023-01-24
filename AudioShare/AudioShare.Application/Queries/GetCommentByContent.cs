using AudioShare.Core.Entities;
using MediatR;
using System.Numerics;

namespace AudioShare.Application.Queries
{
    public class GetCommentById : IRequest<Comment>
    {
        public int Id { get; set; }
    }
}
