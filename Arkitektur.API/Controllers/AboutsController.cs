using Arkitektur.Business.DTOs.AboutDtos;
using Arkitektur.Business.Services.AboutServices;
using Microsoft.AspNetCore.Mvc;

namespace Arkitektur.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AboutsController(IAboutService service) : ControllerBase
    {

        [HttpGet]
        public async Task<ActionResult<ResultAboutDto>> GetAll()
        {
            var response = await service.GetAllAsync();
            return response.IsSuccessful ? Ok(response) : BadRequest(response);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ResultAboutDto>> GetById(int id)
        {
            var response = await service.GetByIdAsync(id);
            return response.IsSuccessful ? Ok(response) : BadRequest(response);
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateAboutDto aboutDto)
        {
            var response = await service.CreateAsync(aboutDto);
            return response.IsSuccessful ? Ok(response) : BadRequest(response);

        }

        [HttpPut]
        public async Task<IActionResult> Update(UpdateAboutDto aboutDto)
        {
            var response = await service.UpdateAsync(aboutDto);
            return response.IsSuccessful ? Ok() : BadRequest(response);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var response = await service.DeleteAsync(id);
            return response.IsSuccessful ? Ok() : BadRequest(response);
        }
    }
}
