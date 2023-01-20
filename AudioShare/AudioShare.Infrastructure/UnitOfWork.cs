using AudioShare.Infrastructure;
using AudioShare.Application.Abstract;
using AudioShare.Infrastructure.Repository;
using System.Threading.Tasks;

namespace AudioShare.Infrastructure
{

    public class UnitOfWork : IUnitOfWork
    {
        private readonly AppDbContext _context;

        public UnitOfWork(
            AppDbContext context,
            IAudioFileRepository audioFileRepository,
            ICommentRepository commentRepository)
        {
            _context = context;
            AudioFileRepository = audioFileRepository;
            CommentRepository = commentRepository;
        }

        public IAudioFileRepository AudioFileRepository { get; private set; }
        public ICommentRepository CommentRepository { get; private set; }

        public void Dispose()
        {
            _context.Dispose();
        }

        public async Task SaveAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}
