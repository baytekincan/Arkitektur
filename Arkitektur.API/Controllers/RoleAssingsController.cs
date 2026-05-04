using Arkitektur.Business.DTOs.RoleAssingDtos;
using Arkitektur.Business.Services.RoleAssignService.cs;
using Microsoft.AspNetCore.Mvc;

namespace Arkitektur.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class RoleAssingsController(IRoleAssignService roleAssignService) : ControllerBase
{
    [HttpGet("{id}")]
    public async Task<ActionResult<List<AssingRoleDto>>> GetUserForRoleAssign(int id)
    {
        var result = await roleAssignService.GetUserForRoleAssignAsync(id);
        return result.IsSuccessful ? Ok(result) : BadRequest(result);
    }

    [HttpPost]
    public async Task<ActionResult> AssingRoleToUser(List<AssingRoleDto> assingRoleDto)
    {
        var result = await roleAssignService.AssingRoleToUserAsync(assingRoleDto);
        return result.IsSuccessful ? Ok(result) : BadRequest(result);
    }
}