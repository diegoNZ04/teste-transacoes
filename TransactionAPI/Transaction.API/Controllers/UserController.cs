using Microsoft.AspNetCore.Mvc;
using Transaction.Application.Services.Interfaces;
using Transaction.Domain.Dtos.Requests;

namespace Transaction.API.Controllers;
#pragma warning disable CS1591

[ApiController]
[Route("api/users")]
public class UserController : ControllerBase
{
    private readonly IUserService _userService;
    public UserController(IUserService userService)
    {
        _userService = userService;
    }

    /// <summary>
    /// Create a new User.
    /// </summary>
    /// <param name="request"></param>
    /// <returns>A newly created User</returns>
    /// <remarks>
    /// Sample request:
    /// POST /api/users/create-user
    /// {
    ///    "name": "John Doe",
    ///    "age": 30
    /// }
    /// </remarks>
    /// <response code="201">Returns the newly created User</response>
    [HttpPost("create-user")]
    public async Task<IActionResult> CreateUser([FromBody] CreateNewUserRequest request)
    {
        var response = await _userService.CreateNewUserAsync(request.Name, request.Age);
        return CreatedAtAction(nameof(GetUserById), new { id = response.Id }, response);
    }

    /// <summary>
    /// Delete a user by ID and all transactions related to him
    /// </summary>
    /// <param name="id"></param>
    /// <returns> Not contain user</returns>
    /// <response code="204">Returns that does not contain user</response>
    /// <response code="404">If user is not found</response>
    [HttpDelete("delete-user/{id}")]
    public async Task<IActionResult> DeleteUser(int id)
    {
        var user = await _userService.GetUserByIdAsync(id);

        if (user == null)
            return NotFound($"User with ID {id} not found.");

        await _userService.DeleteUserById(id);
        return NoContent();
    }

    /// <summary>
    /// Get all users with the general balance of income, expenses and balance, below returns a list with the total balance of the system
    /// </summary>
    /// <returns> Return all users</returns>
    /// <response code="200">Returns users and general balance</response>
    /// <response code="204">If users no content</response>
    [HttpGet("get-all-users")]
    public async Task<ActionResult> GetAllUsers()
    {
        var (users, summary) = await _userService.GetAllUsersAsync();

        if (!users.Any())
            return NoContent();

        return Ok(new { users, summary });
    }

    /// <summary>
    /// Get user by ID and all transactions related to him
    /// </summary>
    /// <param name="id"></param>
    /// <returns> Returns user by ID</returns>
    /// <response code="200">Returns user by ID and all transactions related to him</response>
    /// <response code="404">If user is not found</response>
    [HttpGet("get-user-by-id/{id}")]
    public async Task<IActionResult> GetUserById(int id)
    {
        var response = await _userService.GetUserByIdAsync(id);

        if (response == null)
            return NotFound($"User with ID {id} not found.");

        return Ok(response);
    }
}
#pragma warning restore CS1591
