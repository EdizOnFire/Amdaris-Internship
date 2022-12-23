using AudioEditor.Application.Abstract;
using AudioEditor.Controllers;
using AudioEditor.Infrastructure;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Moq;

namespace AudioEditor.Tests
{
    public class FileUploadControllerTests
    {
        readonly Mock<IWebHostEnvironment> hostingEnvironment = new();
        readonly Mock<IStorageService> storageService = new();
        readonly AppDbContext dbContext = new();
        readonly Mock<ILogger<FileUploadController>> logger = new();

        [Fact]
        public void FileUploadController_Upload_ReturnОk()
        {
            var audioFile = new Mock<IFormFile>();
            audioFile.Setup(f => f.FileName).Returns("audio.mp3");
            var audioFiles = new List<IFormFile> { audioFile.Object };

            var controller = new FileUploadController(hostingEnvironment.Object, storageService.Object, dbContext, logger.Object);
            var result = controller.Upload(audioFiles);

            var okResult = Assert.IsType<OkObjectResult>(result);
            var returnValue = Assert.IsType<string>(okResult.Value);
            Assert.Equal("File/s uploaded.", returnValue);
        }

        [Fact]
        public void FileUploadController_Upload_ReturnBadRequest()
        {
            var audioFile = new Mock<IFormFile>();
            audioFile.Setup(f => f.FileName).Returns("file");
            var audioFiles = new List<IFormFile> { audioFile.Object };

            var controller = new FileUploadController(hostingEnvironment.Object, storageService.Object, dbContext, logger.Object);
            var result = controller.Upload(audioFiles);

            var badRequest = Assert.IsType<BadRequestObjectResult>(result);
            var returnValue = Assert.IsType<string>(badRequest.Value);
            Assert.Equal("Unsupported file format.", returnValue);
        }
    }
}
