using AudioShare.Application.Abstract;
using AudioShare.Controllers;
using AudioShare.Infrastructure;
using Azure.Storage.Blobs;
using Azure.Storage.Blobs.Specialized;
using FluentAssertions;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Moq;

namespace AudioShare.Tests
{
    public class BlobStorageControllerTests
    {
        readonly BlobServiceClient blobServiceClient = null!;
        readonly Mock<IWebHostEnvironment> hostingEnvironment = new();
        readonly Mock<IStorageService> storageService = new();
        readonly AppDbContext dbContext = null!;
        readonly Mock<ILogger<BlobStorageController>> logger = new();

        [Fact]
        public void BlobStorageController_Upload_ReturnОk()
        {
            var audioFile = new Mock<IFormFile>();
            audioFile.Setup(f => f.FileName).Returns("audio.mp3");
            string title = "title";
            string description = "description";
            string user = "email@email.com";

            var controller = new BlobStorageController(blobServiceClient, hostingEnvironment.Object, storageService.Object, dbContext, logger.Object);
            var result = controller.Upload(audioFile.Object, title, description, user);

            var okResult = Assert.IsType<OkObjectResult>(result);
            var returnValue = Assert.IsType<string>(okResult.Value);
            Assert.Equal("File uploaded.", returnValue);
        }

        [Fact]
        public void BlobStorageController_Upload_ReturnBadRequest()
        {
            var audioFile = new Mock<IFormFile>();
            audioFile.Setup(f => f.FileName).Returns("file");
            string title = "title";
            string description = "description";
            string user = "email@email.com";

            var controller = new BlobStorageController(blobServiceClient, hostingEnvironment.Object, storageService.Object, dbContext, logger.Object);
            var result = controller.Upload(audioFile.Object, title, description, user);

            var badRequest = Assert.IsType<BadRequestObjectResult>(result);
            var returnValue = Assert.IsType<string>(badRequest.Value);
            Assert.Equal("Unsupported file format.", returnValue);
        }
    }
}
