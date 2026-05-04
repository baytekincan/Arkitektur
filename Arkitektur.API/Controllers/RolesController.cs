using Arkitektur.Business.DTOs.RoleDtos;
using Arkitektur.Business.Services.RoleServices;
using Microsoft.AspNetCore.Mvc;

namespace Arkitektur.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class RolesController(IRoleService roleService) : ControllerBase
{
    [HttpPost("CreateRole")]
    public async Task<IActionResult> CreateRole(CreateRoleDto createRoleDto)
    {
        var response = await roleService.CreateRole(createRoleDto);
        return response.IsSuccessful ? Ok(response) : BadRequest(response);
    }

    [HttpGet]
    public async Task<ActionResult<List<ResultRoleDto>>> GetAllRoles()
    {
        var response = await roleService.GetAllRolesAsync();
        return response.IsSuccessful ? Ok(response) : BadRequest(response);
    }
}
