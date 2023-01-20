using AudioShare.Application.Abstract;
using AudioShare.Application.Exceptions;
using AudioShare.Application.Services;
using AudioShare.Core.Entities;
using AudioShare.Infrastructure;
using Azure.Storage.Blobs;
using Azure.Storage.Blobs.Specialized;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.Identity.Web.Resource;

namespace AudioShare.Controllers
{
    [Route("audio-share")]
    [ApiController]
    public class BlobStorageController : ControllerBase
    {
        private readonly BlobServiceClient _blobServiceClient;
        public IWebHostEnvironment _hostingEnvironment;
        public IStorageService _storageService;
        public AppDbContext _dbContext;
        private readonly ILogger<BlobStorageController> _logger;
        public BlobStorageController(BlobServiceClient blobServiceClient, IWebHostEnvironment hostingEnvironment, IStorageService storageService, AppDbContext dbContext, ILogger<BlobStorageController> logger)
        {
            _hostingEnvironment = hostingEnvironment;
            _storageService = storageService;
            _dbContext = dbContext;
            _logger = logger;
            _blobServiceClient = blobServiceClient;
        }

        [RequiredScope(RequiredScopesConfigurationKey = "AzureAd:Scopes")]
        [Authorize]
        [HttpPost("upload")]
        public IActionResult Upload(IFormFile file, string title, string description, string user)
        {
            try
            {
                string downloadPath = "https://localhost:5094/audio-share/download/";

                if (file == null)
                {
                    throw new NoFilesSelectedException();
                }

                _logger.LogInformation($"{file}");
                FileInfo fi = new(file.FileName);
                if (fi.Extension != ".mp3" && fi.Extension != ".wav")
                {
                    _logger.LogError("Unsupported file format.");
                    return BadRequest("Unsupported file format.");
                }

                _storageService.Upload(file);
                var audioFile = new AudioFile();
                audioFile.FileName = fi.Name;
                audioFile.Format = fi.Extension;
                audioFile.Title = title;
                audioFile.Description = description;
                audioFile.User = user;
                audioFile.Path = downloadPath + fi;
                _dbContext.AudioFiles.Add(audioFile);
                _dbContext.SaveChanges();

                _logger.LogInformation("File uploaded.");
                return Ok("File uploaded.");
            }
            catch (NoFilesSelectedException e)
            {
                _logger.LogError(e.Message);
                return BadRequest(e.Message);
            }
        }

        [HttpGet("download/{fileName}")]
        public async Task<IActionResult> Download(string fileName)
        {
            var container = _blobServiceClient.GetBlobContainerClient("files");

            var blob = container.GetBlockBlobClient(fileName);

            using var stream = new MemoryStream();
            {
                await blob.DownloadToAsync(stream);
                stream.Position = 0;
                var contentType = (await blob.GetPropertiesAsync()).Value.ContentType;
                _logger.LogInformation("File loaded.");
                return File(stream.ToArray(), contentType, blob.Name);
            }
        }
    }
}
