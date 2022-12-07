using Microsoft.EntityFrameworkCore;
using AudioEditor.Core.Entities;
using AudioEditor.Application.Abstract;

namespace AudioEditor.Infrastructure.Repository
{
    public class AudioFileRepository : IAudioFileRepository
    {
        private readonly AppDbContext _context;

        public AudioFileRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<List<AudioFile>> GetAll()
        {
            return await _context.AudioFiles.ToListAsync();
        }

        public async Task<AudioFile> GetById(int id)
        {
            var audioFile = await _context.AudioFiles.FirstOrDefaultAsync(a => a.Id == id);

            return audioFile;
        }

        public async Task Add(AudioFile audioFile)
        {
            await _context.AudioFiles.AddAsync(audioFile);
        }

        public async Task Update(AudioFile audioFile)
        {
            _context.Update(audioFile);
        }

        public void Remove(AudioFile audioFile)
        {
            _context.AudioFiles.Remove(audioFile);
        }

        public async Task Save()
        {
            await _context.SaveChangesAsync();
        }
    }
}
