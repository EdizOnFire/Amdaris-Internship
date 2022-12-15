using Microsoft.AspNetCore.Mvc;
using AudioEditor.API.Dtos;
using AudioEditor.Application.Queries;
using AudioEditor.Application.Commands;
using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace AudioEditor.API.Controllers
{
    [Route("audio-editor")]
    [ApiController]
    public class AudioFilesController : Controller
    {
        public readonly IMapper _mapper;
        public readonly IMediator _mediator;
        private readonly ILogger<AudioFilesController> _logger;

        public AudioFilesController(IMapper mapper, IMediator mediator, ILogger<AudioFilesController> logger)
        {
            _mediator = mediator;
            _mapper = mapper;
            _logger = logger;
        }

        [HttpGet("audio-files")]
        public async Task<IActionResult> GetAudioFiles()
        {
            var result = await _mediator.Send(new GetAllAudioFiles());
            var mappedResult = _mapper.Map<List<GetAudioFileDto>>(result);
            _logger.LogInformation("Audio files listed successfully.");
            return Ok(mappedResult);
        }

        [HttpGet("audio-files/{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            try
            {
                var query = new GetAudioFileById { Id = id };
                var result = await _mediator.Send(query);

                if (result == null)
                {
                    throw new FileNotFoundException();
                }

                var mappedResult = _mapper.Map<GetAudioFileDto>(result);
                _logger.LogInformation($"Audio file listed successfully.");
                return Ok(mappedResult);
            }
            catch (FileNotFoundException e)
            {
                _logger.LogError(e.Message);
                return BadRequest("Audio file could not be found.");
            }
        }

        [HttpPost("audio-files/create")]
        public async Task<IActionResult> Create([FromBody] CreateAudioFileDto audioFile)
        {
            var command = new CreateAudioFile
            {
                FileName = audioFile.FileName,
                Format = audioFile.Format,
                Path = audioFile.Path,
                LastModified = DateTime.Now,
                UserId = audioFile.UserId
            };

            if (!ModelState.IsValid)
            {
                _logger.LogError("Creating audio file failed.");
                return BadRequest(ModelState);
            }

            var result = await _mediator.Send(command);
            var mappedResult = _mapper.Map<GetAudioFileDto>(result);
            _logger.LogInformation($"Audio file created successfully.");
            return CreatedAtAction(nameof(GetById), new { id = mappedResult.Id }, mappedResult);
        }

        [HttpPut("audio-files/update/{id}")]
        public async Task<IActionResult> Update([FromBody] UpdateAudioFileDto updateAudioFileDto, int id)
        {
            try
            {
                updateAudioFileDto.Id = id;
                var command = _mapper.Map<UpdateAudioFile>(updateAudioFileDto);
                var mappedResult = await _mediator.Send(command);
                _logger.LogInformation($"Audio file updated successfully.");
                return Ok(mappedResult);
            }
            catch (DbUpdateConcurrencyException)
            {
                _logger.LogError("No audio file found for updating.");
                return BadRequest("No audio file found for updating.");
            }
        }

        [HttpDelete("audio-files/delete/{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                var query = new GetAudioFileById { Id = id };
                var result = await _mediator.Send(query);

                if (result == null)
                {
                    throw new FileNotFoundException();
                }

                var command = new DeleteAudioFile { Id = id };
                var actualResult = await _mediator.Send(command);
                _logger.LogInformation($"Audio file deleted successfully.");
                return Ok($"Audio file deleted successfully.");
            }
            catch (FileNotFoundException e)
            {
                _logger.LogError(e.Message);
                return BadRequest("No audio file found for deleting.");
            }
        }
    }
}
