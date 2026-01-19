using Arkitektur.Business.DTOs.CategoryDtos;
using Arkitektur.Business.Services.CategoryServices;
using Microsoft.AspNetCore.Mvc;

namespace Arkitektur.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class CategoriesController(ICategoryService service) : ControllerBase
{
    [HttpGet]
    public async Task<ActionResult<ResultCategoryDto>> GetAll()
    {
        var response = await service.GetAllAsync();
        return response.IsSuccessful ? Ok(response) : BadRequest(response);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<ResultCategoryDto>> GetById(int id)
    {
        var response = await service.GetByIdAsync(id);
        return response.IsSuccessful ? Ok(response) : BadRequest(response);
    }

    [HttpPost]
    public async Task<IActionResult> Create(CreateCategoryDto categoryDto)
    {
        var response = await service.CreateAsync(categoryDto);
        return response.IsSuccessful ? Ok(response) : BadRequest(response);

    }

    [HttpPut]
    public async Task<IActionResult> Update(UpdateCategoryDto categoryDto)
    {
        var response = await service.UpdateAsync(categoryDto);
        return response.IsSuccessful ? Ok() : BadRequest(response);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        var response = await service.DeleteAsync(id);
        return response.IsSuccessful ? Ok() : BadRequest(response);
    }

    [HttpGet("WithProjects")]
    public async Task<ActionResult<ResultCategoriesWithProjectsDto>> GetCategoriesWithProjects()
    {
        var response = await service.GetCategoriesWithProjectsAsync();
        return response.IsSuccessful ? Ok(response) : BadRequest(response);
    }
}
