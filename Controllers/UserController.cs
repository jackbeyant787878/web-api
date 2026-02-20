using asp.net_core_8._0_web_api.DTOs;
using asp.net_core_8._0_web_api.Services;
using Microsoft.AspNetCore.Mvc;

namespace asp.net_core_8._0_web_api.Controllers;

[ApiController]
[Route("[controller]")]
public class UserController : ControllerBase
{
    private readonly IUserService _userService;
    private readonly ILogger<UserController> _logger;

    public UserController(IUserService userService, ILogger<UserController> logger)
    {
        _userService = userService;
        _logger = logger;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<UserDto>>> GetUsers()
    {
        _logger.LogInformation("Getting all users");
        var users = await _userService.GetUsersAsync();
        return Ok(users);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<UserDto>> GetUser(int id)
    {
        _logger.LogInformation($"Getting user with id: {id}");
        var user = await _userService.GetUserByIdAsync(id);
        if (user == null)
        {
            return NotFound();
        }
        return Ok(user);
    }

    [HttpPost]
    public async Task<ActionResult<UserDto>> CreateUser(CreateUserDto createUserDto)
    {
        _logger.LogInformation("Creating a new user");
        var user = await _userService.CreateUserAsync(createUserDto);
        return CreatedAtAction(nameof(GetUser), new { id = user.Id }, user);
    }

    [HttpPut("{id}")]
    public async Task<ActionResult<UserDto>> UpdateUser(int id, UpdateUserDto updateUserDto)
    {
        _logger.LogInformation($"Updating user with id: {id}");
        var user = await _userService.UpdateUserAsync(id, updateUserDto);
        if (user == null)
        {
            return NotFound();
        }
        return Ok(user);
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult<bool>> DeleteUser(int id)
    {
        _logger.LogInformation($"Deleting user with id: {id}");
        var result = await _userService.DeleteUserAsync(id);
        if (!result)
        {
            return NotFound();
        }
        return Ok(result);
    }
}