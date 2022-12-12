using Microsoft.AspNetCore.Mvc;
using AudioEditor.API.Dtos;
using AudioEditor.Application.Queries;
using AudioEditor.Application.Commands;
using AutoMapper;
using MediatR;
using AudioEditor.Core.Entities;

namespace AudioEditor.API.Controllers
{
    [Route("audio-editor")]
    [ApiController]
    public class AudioFilesController : Controller
    {
        public readonly IMapper _mapper;
        public readonly IMediator _mediator;

        public AudioFilesController(IMapper mapper, IMediator mediator)
        {
            _mediator = mediator;
            _mapper = mapper;
        }

        [HttpGet("audio-files")]
        public async Task<IActionResult> GetAudioFiles()
        {
            var result = await _mediator.Send(new GetAllAudioFiles());
            var mappedResult = _mapper.Map<List<GetAudioFileDto>>(result);
            return Ok(mappedResult);
        }

        [HttpGet("audio-files/{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var query = new GetAudioFileById { Id = id };
            var result = await _mediator.Send(query);

            if (result == null)
                return NotFound();

            var mappedResult = _mapper.Map<GetAudioFileDto>(result);
            return Ok(mappedResult);
        }

        [HttpPost("audio-files/create")]
        public async Task<IActionResult> Create([FromBody] CreateAudioFileDto audioFile)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var command = new CreateAudioFile
            {
                FileName = audioFile.FileName,
                Format = audioFile.Format,
                Path = audioFile.Path,
                LastModified = DateTime.Now,
                UserId = audioFile.UserId
            };

            var result = await _mediator.Send(command);
            var mappedResult = _mapper.Map<GetAudioFileDto>(result);

            return CreatedAtAction(nameof(GetById), new { id = mappedResult.Id }, mappedResult);
        }

        [HttpPut("audio-files/update/{id}")]
        public async Task<IActionResult> Update([FromBody] UpdateAudioFileDto updateAudioFileDto, int id)
        {
            var command = _mapper.Map<UpdateAudioFile>(updateAudioFileDto);

            command.Id = id;

            AudioFile result = await _mediator.Send(command);

            if (result == null)
            {
                return NotFound();
            }

            return Ok(result);
        }

        [HttpDelete("audio-files/delete/{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var command = new DeleteAudioFile { Id = id };
            var result = await _mediator.Send(command);

            if (result == null)
                return NotFound();

            return Ok("Deleted successfully.");
        }
    }
}
