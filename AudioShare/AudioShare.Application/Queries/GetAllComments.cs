using AudioShare.Core.Entities;
using MediatR;

namespace AudioShare.Application.Queries
{
    public class GetAllComments : IRequest<List<Comment>>
    {
    }
}
