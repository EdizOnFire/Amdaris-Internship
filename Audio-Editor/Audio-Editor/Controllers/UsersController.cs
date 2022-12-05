using Microsoft.AspNetCore.Mvc;
using AudioEditor.Core.Models;
using AudioEditor.Application.Services;

namespace AudioEditor.API.Controllers
{
    [Route("audio-editor")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        public UsersService _usersService;
        public UsersController(UsersService usersService)
        {
            _usersService = usersService;
        }

        [HttpGet("users")]
        public IActionResult GetAllUsers()
        {
            var allUsers = _usersService.GetAllUsers();
            return Ok(allUsers);
        }

        [HttpGet("users/{id}")]
        public IActionResult GetUserById(int id)
        {
            var user = _usersService.GetUserById(id);
            return Ok(user);
        }

        [HttpPost("users/create")]
        public IActionResult AddUser([FromBody] User user)
        {
            _usersService.AddUser(user);
            return Ok(user);
        }

        [HttpPut("users/update/{id}")]
        public IActionResult UpdateUserById(int id, [FromBody] User user)
        {
            var updatedUser = _usersService.UpdateUserById(id, user);
            return Ok(updatedUser);
        }

        [HttpDelete("users/delete/{id}")]
        public IActionResult DeleteUserById(int id)
        {
            _usersService.DeleteUserById(id);
            return Ok("Deleted successfully.");
        }
    }
}