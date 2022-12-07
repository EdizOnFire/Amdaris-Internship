using AudioEditor.Core.Entities;

namespace AudioEditor.Application.Abstract
{
    public interface IAudioFileRepository
    {
        Task<AudioFile> GetById(int id);

        Task Add(AudioFile audioFile);

        void Remove(AudioFile audioFile);

        Task<List<AudioFile>> GetAll();

        Task Update(AudioFile audioFile);
    }
}
