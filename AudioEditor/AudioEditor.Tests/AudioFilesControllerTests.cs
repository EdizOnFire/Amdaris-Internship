using FluentAssertions;
using Microsoft.AspNetCore.Mvc;
using AudioEditor.API.Controllers;
using MediatR;
using AutoMapper;
using AudioEditor.API.Dtos;
using Moq;
using AudioEditor.Core.Entities;
using Microsoft.Extensions.Logging;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace AudioEditor.Tests.Controller
{
    public class AudioFilesControllerTest
    {
        readonly Mock<IMediator> mediator = new();
        readonly Mock<IMapper> mapperMock = new();
        readonly Mock<ILogger<AudioFilesController>> logger = new();

        [Fact]
        public async void AudioFilesController_GetAudioFiles_ReturnÎê()
        {
            var audioFiles = new Mock<IEnumerable<GetAudioFileDto>>();

            mapperMock.Setup(m => m.Map<List<GetAudioFileDto>>(audioFiles)).Returns(new List<GetAudioFileDto>());
            var controller = new AudioFilesController(mapperMock.Object, mediator.Object, logger.Object);

            var result = await controller.GetAudioFiles();

            result.Should().BeOfType(typeof(OkObjectResult));
        }

        //[Fact]
        //public async void AudioFilesController_GetById_ReturnÎê()
        //{
        //    var id = 1;
        //    var audioFile = new Mock<GetAudioFileDto>();

        //    mapperMock.Setup(m => m.Map<GetAudioFileDto>(audioFile)).Returns(new GetAudioFileDto());

        //    var controller = new AudioFilesController(mapperMock.Object, mediator.Object, logger.Object);

        //    var result = await controller.GetById(id);

        //    result.Should().BeOfType(typeof(ObjectResult));
        //}

        [Fact]
        public async void AudioFilesController_Update_ReturnÎê()
        {
            var id = 1;
            var audioFile = new Mock<UpdateAudioFileDto>();

            mapperMock.Setup(m => m.Map<UpdateAudioFileDto>(audioFile)).Returns(new UpdateAudioFileDto());
            var controller = new AudioFilesController(mapperMock.Object, mediator.Object, logger.Object);

            var result = await controller.Update(new UpdateAudioFileDto(), id);

            result.Should().BeOfType(typeof(OkObjectResult));
        }

        //[Fact]
        //public async void AudioFilesController_Delete_ReturnÎê()
        //{
        //    var id = 1;
        //    var audioFile = new Mock<GetAudioFileDto>();

        //    mapperMock.Setup(m => m.Map<GetAudioFileDto>(audioFile)).Returns(new GetAudioFileDto());
        //    var controller = new AudioFilesController(mapperMock.Object, mediator.Object, logger.Object);

        //    var result = await controller.Delete(id);


        //    result.Should().BeOfType(typeof(OkObjectResult));
        //}
    }
}
