using Microsoft.AspNetCore.Mvc;
using Transaction.Application.Services.Interfaces;
using Transaction.Domain.Dtos.Requests;
using Transaction.Domain.Dtos.Responses;

namespace Transaction.API.Controllers
{
    [ApiController]
    [Route("api/users")]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;
        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpPost("create-user")]
        public async Task<IActionResult> CreateUser([FromBody] CreateNewUserRequest request)
        {
            var response = await _userService.CreateNewUserAsync(request.Name, request.Age);
            return CreatedAtAction(nameof(GetUserById), new { id = response.Id }, response);
        }

        [HttpDelete("delete-user/{id}")]
        public async Task<IActionResult> DeleteUser(int id)
        {
            var user = await _userService.GetUserByIdAsync(id);

            if (user == null)
                return NotFound($"User with ID {id} not found.");

            await _userService.DeleteUserById(id);
            return NoContent();
        }

        [HttpGet("get-all-users")]
        public async Task<ActionResult> GetAllUsers()
        {
            var (users, summary) = await _userService.GetAllUsersAsync();

            if (!users.Any())
                return NoContent();

            return Ok(new { users, summary });
        }

        [HttpGet("get-user-by-id/{id}")]
        public async Task<IActionResult> GetUserById(int id)
        {
            var response = await _userService.GetUserByIdAsync(id);

            if (response == null)
                return NotFound($"User with ID {id} not found.");

            return Ok(response);
        }
    }
}