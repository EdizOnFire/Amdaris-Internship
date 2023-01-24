using FluentAssertions;
using Microsoft.AspNetCore.Mvc;
using AudioShare.API.Controllers;
using MediatR;
using AutoMapper;
using AudioShare.API.Dtos;
using Moq;
using AudioShare.Core.Entities;
using Microsoft.Extensions.Logging;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;
using AudioShare.Application.Queries;
using AudioShare.Application.Commands;

namespace AudioShare.Tests.Controller
{
    public class AudioFilesControllerTest
    {
        readonly Mock<IMediator> mediator = new();
        readonly Mock<IMapper> mapper = new();
        readonly Mock<ILogger<AudioFilesController>> logger = new();

        [Fact]
        public async void AudioFilesController_GetAudioFiles_ReturnOk()
        {
            var audioFiles = new List<AudioFile>();
            var audioFilesDto = new List<GetAudioFileDto>();
            var expectedResult = new List<AudioFile>();
            {
                new AudioFile { Id = 1, FileName = "Item 1" };
                new AudioFile { Id = 2, FileName = "Item 2" };
            }

            mediator.Setup(x => x.Send(It.IsAny<GetAllAudioFiles>(), default)).ReturnsAsync(expectedResult);
            mapper.Setup(x => x.Map<IEnumerable<GetAudioFileDto>>(audioFiles)).Returns(audioFilesDto);

            var controller = new AudioFilesController(mapper.Object, mediator.Object, logger.Object);

            var result = await controller.GetAudioFiles();

            result.Should().BeOfType(typeof(OkObjectResult));
        }

        [Fact]
        public async void AudioFilesController_GetById_ReturnOk()
        {
            var id = 1;
            var audioFile = new AudioFile { Id = 1, FileName = "Item 1" };
            var audioFileDto = new GetAudioFileDto { Id = 1, FileName = "Item 1" };

            mediator.Setup(x => x.Send(It.IsAny<GetAudioFileById>(), default)).ReturnsAsync(audioFile);
            mapper.Setup(m => m.Map<GetAudioFileDto>(audioFile)).Returns(audioFileDto);

            var controller = new AudioFilesController(mapper.Object, mediator.Object, logger.Object);

            var result = await controller.GetById(id);

            result.Should().BeOfType(typeof(OkObjectResult));
        }

        [Fact]
        public async void AudioFilesController_GetById_ReturnBadRequest()
        {
            var id = 1;
            var audioFile = new Mock<AudioFile>();
            var audioFileDto = new Mock<GetAudioFileDto>();

            mediator.Setup(x => x.Send(It.IsAny<GetAudioFileById>(), default)).Throws(new FileNotFoundException());
            mapper.Setup(m => m.Map<GetAudioFileDto>(audioFile)).Returns(new GetAudioFileDto());

            var controller = new AudioFilesController(mapper.Object, mediator.Object, logger.Object);

            var result = await controller.GetById(id);

            result.Should().BeOfType(typeof(BadRequestObjectResult));
        }

        [Fact]
        public async void AudioFilesController_Update_ReturnOk()
        {
            var audioFile = new AudioFile { FileName = "Item 1" };
            var audioFileDto = new UpdateAudioFileDto { FileName = "Item 1" };
            int id = 1;

            mediator.Setup(x => x.Send(It.IsAny<UpdateAudioFile>(), default)).ReturnsAsync(audioFile);
            mapper.Setup(m => m.Map<UpdateAudioFileDto>(audioFileDto)).Returns(new UpdateAudioFileDto());

            var controller = new AudioFilesController(mapper.Object, mediator.Object, logger.Object);

            var result = await controller.Update(new UpdateAudioFileDto(),  id);

            result.Should().BeOfType(typeof(OkObjectResult));
        }

        [Fact]
        public async void AudioFilesController_Delete_ReturnOk()
        {
            var id = 1;
            var audioFile = new AudioFile { Id = 1, FileName = "Item 1" };

            mediator.Setup(x => x.Send(It.IsAny<GetAudioFileById>(), default)).ReturnsAsync(audioFile);

            var controller = new AudioFilesController(mapper.Object, mediator.Object, logger.Object);

            var result = await controller.Delete(id);

            result.Should().BeOfType(typeof(OkObjectResult));
        }
    }
}
