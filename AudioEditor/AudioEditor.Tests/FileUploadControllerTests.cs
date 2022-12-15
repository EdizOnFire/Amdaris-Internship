using AudioEditor.API.Controllers;
using AudioEditor.API.Dtos;
using AudioEditor.Application.Abstract;
using AudioEditor.Controllers;
using AudioEditor.Infrastructure;
using MediatR;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AudioEditor.Tests
{
    public class FileUploadControllerTests
    {
        public IWebHostEnvironment hostingEnvironment;
        public IStorageService storageService;
        public AppDbContext dbContext;
        private readonly ILogger<FileUploadController> logger;

        [Fact]
        public async void AudioFilesController_GetAudioFiles_ReturnОк()
        {

        }
    }
}
