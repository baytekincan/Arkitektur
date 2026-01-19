using Arkitektur.Business.DTOs.ProjectDtos;
using Arkitektur.Business.Services.ProjectServices;
using Microsoft.AspNetCore.Mvc;

namespace Arkitektur.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ProjectsController(IProjectService service) : ControllerBase
{
    [HttpGet]
    public async Task<ActionResult<ResultProjectDto>> GetAll()
    {
        var response = await service.GetAllAsync();
        return response.IsSuccessful ? Ok(response) : BadRequest(response);
    }

    [HttpGet("WithCategories")]
    public async Task<ActionResult<ResultProjectDto>> GetProjectsWithCategories()
    {
        var response = await service.GetProjectsWithCategoriesAsync();
        return response.IsSuccessful ? Ok(response) : BadRequest(response);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<ResultProjectDto>> GetById(int id)
    {
        var response = await service.GetByIdAsync(id);
        return response.IsSuccessful ? Ok(response) : BadRequest(response);
    }

    [HttpPost]
    public async Task<IActionResult> Create(CreateProjectDto projectDto)
    {
        var response = await service.CreateAsync(projectDto);
        return response.IsSuccessful ? Ok(response) : BadRequest(response);

    }

    [HttpPut]
    public async Task<IActionResult> Update(UpdateProjectDto projectDto)
    {
        var response = await service.UpdateAsync(projectDto);
        return response.IsSuccessful ? Ok() : BadRequest(response);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        var response = await service.DeleteAsync(id);
        return response.IsSuccessful ? Ok() : BadRequest(response);
    }
}
