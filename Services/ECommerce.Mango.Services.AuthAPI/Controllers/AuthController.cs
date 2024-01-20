using ECommerce.Mango.Services.AuthAPI.Interfaces;
using ECommerce.Mango.Services.AuthAPI.Models;
using Microsoft.AspNetCore.Mvc;

namespace ECommerce.Mango.Services.AuthAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class AuthController(IAuthService service) : ControllerBase
{
    private readonly IAuthService _service = service;

    [HttpPost("login")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> Login([FromBody] AuthRequest request)
    {
        return Ok(await _service.Login(request));
    }

    [HttpPost("register")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> Register([FromBody] RegistrationRequest request)
    {
        await _service.Register(request);
        return Ok();
    }
}
