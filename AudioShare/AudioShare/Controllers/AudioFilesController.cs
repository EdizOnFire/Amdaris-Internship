using Microsoft.AspNetCore.Mvc;
using AudioShare.API.Dtos;
using AudioShare.Application.Queries;
using AudioShare.Application.Commands;
using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authorization;
using Microsoft.Identity.Web.Resource;

namespace AudioShare.API.Controllers
{
    [RequiredScope(RequiredScopesConfigurationKey = "AzureAd:Scopes")]
    [Authorize]
    [ApiController]
    [Route("audio-share")]
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
            try
            {
                var result = await _mediator.Send(new GetAllAudioFiles());
                var mappedResult = _mapper.Map<List<GetAudioFileDto>>(result);
                _logger.LogInformation("Audio files listed successfully.");

                return Ok(mappedResult);
            }
            catch (Exception e)
            {
                _logger.LogError(e.Message);
                return BadRequest(e.Message);
            }
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

        [HttpPut("audio-files/update/{id}")]
        public async Task<IActionResult> Update([FromBody] UpdateAudioFileDto updateAudioFileDto)
        {
            try
            {
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
                _logger.LogInformation("Audio file deleted successfully.");
                return Ok("Audio file deleted successfully.");
            }
            catch (FileNotFoundException e)
            {
                _logger.LogError(e.Message);
                return BadRequest("No audio file found for deleting.");
            }
        }
    }
}
