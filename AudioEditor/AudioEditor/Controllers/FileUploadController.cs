using AudioEditor.Application.Abstract;
using AudioEditor.Application.Exceptions;
using AudioEditor.Core.Entities;
using AudioEditor.Infrastructure;
using Microsoft.AspNetCore.Mvc;

namespace AudioEditor.Controllers
{
    [Route("audio-editor")]
    [ApiController]
    public class FileUploadController : ControllerBase
    {
        public IWebHostEnvironment _hostingEnvironment;
        public IStorageService _storageService;
        public AppDbContext _dbContext;
        private readonly ILogger<FileUploadController> _logger;
        public FileUploadController(IWebHostEnvironment hostingEnvironment, IStorageService storageService, AppDbContext dbContext, ILogger<FileUploadController> logger)
        {
            _hostingEnvironment = hostingEnvironment;
            _storageService = storageService;
            _dbContext = dbContext;
            _logger = logger;
        }

        [HttpPost("upload")]
        public IActionResult Upload(List<IFormFile> files)
        {
            try
            {
                string filesPath = "https://audioeditor.blob.core.windows.net/files/";

                if (files.Count == 0)
                {
                    throw new NoFilesSelectedException();
                }

                foreach (var file in files)
                {
                    FileInfo fi = new(file.FileName);
                    if (fi.Extension != ".mp3" && fi.Extension != ".wav")
                    {
                        _logger.LogError("Unsupported file format.");
                        return BadRequest("Unsupported file format.");
                    }

                    _storageService.Upload(file);
                    AudioFile audioFile = new();
                    audioFile.FileName = fi.Name;
                    audioFile.Format = fi.Extension;
                    audioFile.Path = filesPath + fi;
                    audioFile.LastModified = DateTime.Now;
                    _dbContext.AudioFiles.Add(audioFile);
                    _dbContext.SaveChanges();
                }

                _logger.LogInformation("File/s uploaded.");
                return Ok("File/s uploaded.");
            }
            catch (NoFilesSelectedException e)
            {
                _logger.LogError(e.Message);
                return BadRequest(e.Message);
            }
        }
    }
}
