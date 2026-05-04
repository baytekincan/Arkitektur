using Arkitektur.Business.Base;
using Arkitektur.Business.DTOs.RoleAssingDtos;
using Arkitektur.Entity.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace Arkitektur.Business.Services.RoleAssignService.cs;


public class RoleAssignService(UserManager<AppUser> userManager, RoleManager<AppRole> roleManager) : IRoleAssignService
{
    public async Task<BaseResult<object>> AssingRoleToUserAsync(List<AssingRoleDto> assingRoleDto)
    {
        var userId = assingRoleDto.Select(x => x.UserId).FirstOrDefault();
        var user = await userManager.FindByIdAsync(userId.ToString());

        if (user == null)
        {
            return BaseResult<object>.Fail("User not found");
        }

        foreach (var role in assingRoleDto)
        {
            if (role.RoleExist)
            {
                await userManager.AddToRoleAsync(user, role.RoleName);
            }
            else
            {
                await userManager.RemoveFromRoleAsync(user, role.RoleName);
            }
        }
        return BaseResult<object>.Success();
    }

    public async Task<BaseResult<List<AssingRoleDto>>> GetUserForRoleAssignAsync(int id)
    {
        var user = await userManager.FindByIdAsync(id.ToString());

        if (user is null)
        {
            return BaseResult<List<AssingRoleDto>>.Fail("User not found");
        }

        var roles = await roleManager.Roles.ToListAsync();
        var userRoles = await userManager.GetRolesAsync(user);

        var roleAssignments = new List<AssingRoleDto>();

        foreach (var role in roles)
        {
            var roleAssignment = new AssingRoleDto
            {
                UserId = user.Id,
                RoleId = role.Id,
                RoleName = role.Name,
                RoleExist = userRoles.Contains(role.Name)
            };
            roleAssignments.Add(roleAssignment);
        }
        return BaseResult<List<AssingRoleDto>>.Success(roleAssignments);
    }
}
