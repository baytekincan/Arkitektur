using Arkitektur.Business.DTOs.ContactDtos;
using Arkitektur.Business.Services.ContactServices;
using Microsoft.AspNetCore.Mvc;

namespace Arkitektur.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ContactsController(IContactService service) : ControllerBase
{
    [HttpGet]
    public async Task<ActionResult<ResultContactDto>> GetAll()
    {
        var response = await service.GetAllAsync();
        return response.IsSuccessful ? Ok(response) : BadRequest(response);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<ResultContactDto>> GetById(int id)
    {
        var response = await service.GetByIdAsync(id);
        return response.IsSuccessful ? Ok(response) : BadRequest(response);
    }

    [HttpPost]
    public async Task<IActionResult> Create(CreateContactDto ContactDto)
    {
        var response = await service.CreateAsync(ContactDto);
        return response.IsSuccessful ? Ok(response) : BadRequest(response);

    }

    [HttpPut]
    public async Task<IActionResult> Update(UpdateContactDto ContactDto)
    {
        var response = await service.UpdateAsync(ContactDto);
        return response.IsSuccessful ? Ok() : BadRequest(response);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        var response = await service.DeleteAsync(id);
        return response.IsSuccessful ? Ok() : BadRequest(response);
    }
}
