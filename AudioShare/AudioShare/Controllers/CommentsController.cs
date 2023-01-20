using AudioShare.API.Controllers;
using AudioShare.API.Dtos;
using AudioShare.Application.Commands;
using AudioShare.Application.Exceptions;
using AudioShare.Application.Queries;
using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Web.Resource;

namespace AudioShare.Controllers
{
    [Route("audio-share/comments")]
    [ApiController]
    public class CommentsController : ControllerBase
    {
        public readonly IMapper _mapper;
        public readonly IMediator _mediator;
        private readonly ILogger<CommentsController> _logger;

        public CommentsController(IMapper mapper, IMediator mediator, ILogger<CommentsController> logger)
        {
            _mediator = mediator;
            _mapper = mapper;
            _logger = logger;
        }

        [HttpGet]
        public async Task<IActionResult> GetComments()
        {
            try
            {
                var result = await _mediator.Send(new GetAllComments());
                var mappedResult = _mapper.Map<List<GetCommentDto>>(result);
                _logger.LogInformation("Comments listed successfully.");

                return Ok(mappedResult);
            }
            catch (Exception e)
            {
                _logger.LogError(e.Message);
                return BadRequest(e.Message);
            }
        }

        [HttpGet("{owner}")]
        public async Task<IActionResult> GetByOwner(string owner)
        {
            try
            {
                var query = new GetCommentByOwner { Owner = owner };
                var result = await _mediator.Send(query);

                if (result == null)
                {
                    throw new FileNotFoundException();
                }

                var mappedResult = _mapper.Map<GetCommentDto>(result);
                _logger.LogInformation($"Comment listed successfully.");
                return Ok(mappedResult);
            }
            catch (FileNotFoundException e)
            {
                _logger.LogError(e.Message);
                return BadRequest(e.Message);
            }
        }

        [RequiredScope(RequiredScopesConfigurationKey = "AzureAd:Scopes")]
        [Authorize]
        [HttpPost]
        public async Task<IActionResult> CreateComment([FromBody] GetCommentDto comment)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var command = new CreateComment
            {
                Owner = comment.Owner,
                Content = comment.Content,
            };

            var result = await _mediator.Send(command);
            var mappedResult = _mapper.Map<GetCommentDto>(result);

            return CreatedAtAction(nameof(GetByOwner), new { owner = mappedResult.Owner }, mappedResult);
        }

        [RequiredScope(RequiredScopesConfigurationKey = "AzureAd:Scopes")]
        [Authorize]
        [HttpDelete("delete/{owner}")]
        public async Task<IActionResult> Delete(string owner, string currentUser)
        {
            try
            {
                var query = new GetCommentByOwner { Owner = owner };
                var result = await _mediator.Send(query);

                if (result == null)
                {
                    throw new FileNotFoundException();
                }
                else if (result.Owner != currentUser)
                {
                    throw new NotOwnerException();
                }

                var command = new DeleteComment { Owner = owner };
                var actualResult = await _mediator.Send(command);
                _logger.LogInformation("Comment deleted successfully.");
                return Ok("Comment deleted successfully.");
            }
            catch (FileNotFoundException e)
            {
                _logger.LogError(e.Message);
                return BadRequest(e.Message);
            }
            catch (NotOwnerException e)
            {
                _logger.LogError(e.Message);
                return Unauthorized(e.Message);
            }
        }
    }
}
