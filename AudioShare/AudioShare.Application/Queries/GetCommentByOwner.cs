using AudioShare.Core.Entities;
using MediatR;
using System.Numerics;

namespace AudioShare.Application.Queries
{
    public class GetCommentByOwner : IRequest<Comment>
    {
        public string Owner { get; set; } = null!;
    }
}
