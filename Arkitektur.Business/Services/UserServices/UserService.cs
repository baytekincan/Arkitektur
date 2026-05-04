using Arkitektur.Business.Base;
using Arkitektur.Business.DTOs.TokenDtos;
using Arkitektur.Business.DTOs.UserDtos;
using Arkitektur.Business.Services.JwtServices;
using Arkitektur.Entity.Entities;
using Mapster;
using Microsoft.AspNetCore.Identity;

namespace Arkitektur.Business.Services.UserServices;

public class UserService(UserManager<AppUser> userManager, IJwtService jwtService) : IUserService
{
    public async Task<BaseResult<object>> CreateUserAsync(CreateUserDto createUserDto)
    {
        var user = createUserDto.Adapt<AppUser>();
        var result = await userManager.CreateAsync(user, createUserDto.Password);

        if (!result.Succeeded)
        {
            return BaseResult<object>.Fail(result.Errors);
        }

        return BaseResult<object>.Success();
    }

    public async Task<BaseResult<TokenResponseDto>> LoginAsync(LoginDto loginDto)
    {
        var user = await userManager.FindByEmailAsync(loginDto.Email);
        if (user == null)
        {
            return BaseResult<TokenResponseDto>.Fail("User not found");
        }

        var result = await userManager.CheckPasswordAsync(user, loginDto.Password);
        if (!result)
        {
            return BaseResult<TokenResponseDto>.Fail("Invalid password");
        }

        var tokenResponse = await jwtService.GenerateTokenAsync(user);
        return BaseResult<TokenResponseDto>.Success(tokenResponse);
    }
}
