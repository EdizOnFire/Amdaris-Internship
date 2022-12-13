using AudioEditor.Infrastructure;
using AudioEditor.Application.Abstract;
using AudioEditor.Infrastructure.Repository;
using System.Threading.Tasks;

namespace AudioEditor.Infrastructure
{

    public class UnitOfWork : IUnitOfWork
    {
        private readonly AppDbContext _context;

        public UnitOfWork(
            AppDbContext context,
            IAudioFileRepository audioFileRepository)
        {
            _context = context;
            AudioFileRepository = audioFileRepository;
        }

        public IAudioFileRepository AudioFileRepository { get; private set; }

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
