using Arkitektur.Business.DTOs.FeatureDtos;
using Arkitektur.Business.Services.FeatureServices;
using Microsoft.AspNetCore.Mvc;

namespace Arkitektur.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class FeaturesController(IFeatureService service) : ControllerBase
{
    [HttpGet]
    public async Task<ActionResult<ResultFeatureDto>> GetAll()
    {
        var response = await service.GetAllAsync();
        return response.IsSuccessful ? Ok(response) : BadRequest(response);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<ResultFeatureDto>> GetById(int id)
    {
        var response = await service.GetByIdAsync(id);
        return response.IsSuccessful ? Ok(response) : BadRequest(response);
    }

    [HttpPost]
    public async Task<IActionResult> Create(CreateFeatureDto featureDto)
    {
        var response = await service.CreateAsync(featureDto);
        return response.IsSuccessful ? Ok(response) : BadRequest(response);

    }

    [HttpPut]
    public async Task<IActionResult> Update(UpdateFeatureDto featureDto)
    {
        var response = await service.UpdateAsync(featureDto);
        return response.IsSuccessful ? Ok() : BadRequest(response);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        var response = await service.DeleteAsync(id);
        return response.IsSuccessful ? Ok() : BadRequest(response);
    }
}