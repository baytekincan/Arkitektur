
using Arkitektur.Business.DTOs.BannerDtos;
using Arkitektur.Business.Services.BannerServices;
using Microsoft.AspNetCore.Mvc;

namespace Arkitektur.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class BannersController(IBannerService service) : ControllerBase
{
    [HttpGet]
    public async Task<ActionResult<ResultBannerDto>> GetAll()
    {
        var response = await service.GetAllAsync();
        return response.IsSuccessful ? Ok(response) : BadRequest(response);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<ResultBannerDto>> GetById(int id)
    {
        var response = await service.GetByIdAsync(id);
        return response.IsSuccessful ? Ok(response) : BadRequest(response);
    }

    [HttpPost]
    public async Task<IActionResult> Create(CreateBannerDto bannerDto)
    {
        var response = await service.CreateAsync(bannerDto);
        return response.IsSuccessful ? Ok(response) : BadRequest(response);

    }

    [HttpPut]
    public async Task<IActionResult> Update(UpdateBannerDto bannerDto)
    {
        var response = await service.UpdateAsync(bannerDto);
        return response.IsSuccessful ? Ok() : BadRequest(response);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        var response = await service.DeleteAsync(id);
        return response.IsSuccessful ? Ok() : BadRequest(response);
    }
}
