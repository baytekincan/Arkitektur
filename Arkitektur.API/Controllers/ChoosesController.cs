using Arkitektur.Business.DTOs.ChooseDtos;
using Arkitektur.Business.Services.ChooseServices;
using Microsoft.AspNetCore.Mvc;

namespace Arkitektur.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ChoosesController(IChooseService service) : ControllerBase
    {
        [HttpGet]
        public async Task<ActionResult<ResultChooseDto>> GetAll()
        {
            var response = await service.GetAllAsync();
            return response.IsSuccessful ? Ok(response) : BadRequest(response);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ResultChooseDto>> GetById(int id)
        {
            var response = await service.GetByIdAsync(id);
            return response.IsSuccessful ? Ok(response) : BadRequest(response);
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateChooseDto chooseDto)
        {
            var response = await service.CreateAsync(chooseDto);
            return response.IsSuccessful ? Ok(response) : BadRequest(response);

        }

        [HttpPut]
        public async Task<IActionResult> Update(UpdateChooseDto chooseDto)
        {
            var response = await service.UpdateAsync(chooseDto);
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
