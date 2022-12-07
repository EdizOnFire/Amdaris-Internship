using System;
using System.Threading.Tasks;

namespace AudioEditor.Application.Abstract
{
    public interface IUnitOfWork : IDisposable
    {
        public IAudioFileRepository AudioFileRepository { get; }
        Task SaveAsync();
    }
}
