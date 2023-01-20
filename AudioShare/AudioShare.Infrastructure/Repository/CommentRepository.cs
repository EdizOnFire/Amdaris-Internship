using Microsoft.EntityFrameworkCore;
using AudioShare.Core.Entities;
using AudioShare.Application.Abstract;

namespace AudioShare.Infrastructure.Repository
{
    public class CommentRepository : ICommentRepository
    {
        private readonly AppDbContext _context;

        public CommentRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<List<Comment>> GetAll()
        {
            return await _context.Comments.ToListAsync();
        }

        public async Task<Comment> GetByOwner(string owner)
        {
            var comment = await _context.Comments.FirstOrDefaultAsync(a => a.Owner == owner);

            return comment;
        }

        public async Task Add(Comment comment)
        {
            await _context.Comments.AddAsync(comment);
        }

        public async Task Update(Comment comment)
        {
            _context.Update(comment);
        }

        public void Remove(Comment comment)
        {
            _context.Comments.Remove(comment);
        }

        public async Task Save()
        {
            await _context.SaveChangesAsync();
        }
    }
}
