using AudioEditor.Core.Models;
using AudioEditor.Infrastructure.Data;

namespace AudioEditor.Application.Services
{
    public class AudioFilesService
    {
        private readonly AppDbContext _context;
        public AudioFilesService(AppDbContext context)
        {
            _context = context;
        }

        public List<AudioFile> GetAudioFiles() => _context.AudioFiles.ToList();

        public AudioFile GetAudioFileById(int id) => _context.AudioFiles.FirstOrDefault(a => a.Id == id);

        public void AddAudioFile(AudioFile audioFile)
        {
            var _audioFile = new AudioFile()
            {
                FileName = audioFile.FileName,
                Format = audioFile.Format,
                CreatedDate = DateTime.Now,
                ModifiedDate = DateTime.Now
            };
            _context.AudioFiles.Add(_audioFile);
            _context.SaveChanges();
        }

        public AudioFile UpdateAudioFileById(int id, AudioFile audioFile)
        {
            var _audioFile = _context.AudioFiles.FirstOrDefault(a => a.Id == id);
            if (_audioFile != null)
            {
                _audioFile.FileName = audioFile.FileName;
                _audioFile.Format = audioFile.Format;
                _audioFile.ModifiedDate = DateTime.Now;

                _context.SaveChanges();
            }

            return _audioFile;
        }

        public void DeleteAudioFileById(int id)
        {
            var _audioFile = _context.AudioFiles.FirstOrDefault(a => a.Id == id);
            if (_audioFile != null)
            {
                _context.AudioFiles.Remove(_audioFile);
                _context.SaveChanges();
            }
        }
    }
}
