using AudioShare.Core.Entities;
using MediatR;
namespace AudioShare.Application.Commands
{
    public class DeleteComment : IRequest<Comment>
    {
        public string Owner { get; set; } = null!;
    }
}
