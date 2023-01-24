using AudioShare.Core.Entities;

namespace AudioShare.Application.Abstract
{
    public interface ICommentRepository
    {
        Task<Comment> GetById(int id);

        Task Add(Comment comment);

        void Remove(Comment comment);

        Task<List<Comment>> GetAll();

        Task Update(Comment comment);
    }
}
