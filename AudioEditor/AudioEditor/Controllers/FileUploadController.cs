using AudioEditor.Application.Abstract;
using AudioEditor.Core.Entities;
using AudioEditor.Infrastructure;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
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
        public FileUploadController(IWebHostEnvironment hostingEnvironment, IStorageService storageService, AppDbContext dbContext)
        {
            _hostingEnvironment = hostingEnvironment;
            _storageService = storageService;
            _dbContext = dbContext;
        }

        [HttpPost("upload")]
        public IActionResult Upload(List<IFormFile> files)
        {
            if (files.Count > 0)
            {
                foreach (var file in files)
                {
                    _storageService.Upload(file);

                    FileInfo fi = new(file.FileName);
                    AudioFile audioFile = new();
                    audioFile.FileName = fi.Name;
                    audioFile.Format = fi.Extension;
                    audioFile.Path = $"https://audioeditor.blob.core.windows.net/files/{fi}";
                    audioFile.LastModified = DateTime.Now;
                    _dbContext.AudioFiles.Add(audioFile);
                    _dbContext.SaveChanges();

                    //var path = Path.Combine("", _hostingEnvironment.ContentRootPath + "/Files/" + fi);
                    //using var stream = new FileStream(path, FileMode.Create);
                    //{
                    //    await file.CopyToAsync(stream);
                    //}
                }

                return Ok("File/s uploaded.");
            }
            else
            {
                return BadRequest("Select file/s.");
            }
        }
    }
}
