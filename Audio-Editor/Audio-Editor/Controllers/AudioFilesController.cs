using Microsoft.AspNetCore.Mvc;
using AudioEditor.Core.Models;
using AudioEditor.Application.Services;

namespace AudioEditor.API.Controllers
{
    [Route("audio-editor")]
    [ApiController]
    public class AudioFilesController : ControllerBase
    {
        public AudioFilesService _audioFilesService;
        public AudioFilesController(AudioFilesService audioFilesService)
        {
            _audioFilesService = audioFilesService;
        }

        [HttpGet("audio-files")]
        public IActionResult GetAllAudioFiles()
        {
            var allAudioFiles = _audioFilesService.GetAudioFiles();
            return Ok(allAudioFiles);
        }

        [HttpGet("audio-files/{id}")]
        public IActionResult GetAudioFileById(int id)
        {
            var audioFile = _audioFilesService.GetAudioFileById(id);
            return Ok(audioFile);
        }

        [HttpPost("audio-files/create")]
        public IActionResult AddAudioFile([FromBody] AudioFile audioFile)
        {
            _audioFilesService.AddAudioFile(audioFile);
            return Ok(audioFile);
        }

        [HttpPut("audio-files/update/{id}")]
        public IActionResult UpdateAudioFileById(int id, [FromBody] AudioFile audioFile)
        {
            var updatedAudioFile = _audioFilesService.UpdateAudioFileById(id, audioFile);
            return Ok(updatedAudioFile);
        }

        [HttpDelete("audio-files/delete/{id}")]
        public IActionResult DeleteAudioFileById(int id)
        {
            _audioFilesService.DeleteAudioFileById(id);
            return Ok("Deleted successfully.");
        }
    }
}