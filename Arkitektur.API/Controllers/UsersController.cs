using Arkitektur.Business.DTOs.TokenDtos;
using Arkitektur.Business.DTOs.UserDtos;
using Arkitektur.Business.Services.UserServices;
using Microsoft.AspNetCore.Mvc;

namespace Arkitektur.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class UsersController(IUserService userService) : ControllerBase
{
    [HttpPost("register")]

    public async Task<IActionResult> CreateUser(CreateUserDto createUserDto)
    {
        var result = await userService.CreateUserAsync(createUserDto);
        if (!result.IsSuccessful)
        {
            return BadRequest(result.Errors);
        }
        return Ok(result);
    }

    [HttpPost("login")]
    public async Task<ActionResult<TokenResponseDto>> Login(LoginDto loginDto)
    {
        var response = await userService.LoginAsync(loginDto);
        return response.IsSuccessful ? Ok(response.Data) : BadRequest(response.Errors);

    }
}
