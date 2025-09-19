using Microsoft.AspNetCore.Mvc;
using RealEstate.Api.Dtos;
using RealEstate.Api.Services;

namespace RealEstate.Api.Controllers;
[ApiController]
[Route("api/[controller]")]
public class AuthController : ControllerBase {
    private readonly IUserService _userService;
    public AuthController(IUserService userService) => _userService = userService;

    [HttpPost("register")]
    public async Task<IActionResult> Register([FromBody] UserDto dto) {
        var id = await _userService.RegisterAsync(dto);
        if (id == null) return Conflict(new { message = "User exists" });
        return Ok(new { id });
    }

    [HttpPost("login")]
    public async Task<IActionResult> Login([FromBody] UserDto dto) {
        var token = await _userService.AuthenticateAsync(dto);
        if (token == null) return Unauthorized();
        return Ok(new { token });
    }
}