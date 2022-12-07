using AudioEditor.Infrastructure;
using AudioEditor.Application.Abstract;
using AudioEditor.Infrastructure.Repository;
using System.Threading.Tasks;

namespace AudioEditor.Infrastructure
{

    public class UnitOfWork : IUnitOfWork
    {
        private readonly AppDbContext context;

        public UnitOfWork(
            AppDbContext context,
            IAudioFileRepository audioFileRepository)
        {
            this.context = context;
            AudioFileRepository = audioFileRepository;
        }

        public IAudioFileRepository AudioFileRepository { get; private set; }

        public void Dispose()
        {
            this.context.Dispose();
        }

        public async Task SaveAsync()
        {
            await this.context.SaveChangesAsync();
        }
    }
}
