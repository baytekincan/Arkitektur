using Arkitektur.Business.Services.FileServices;
using Microsoft.AspNetCore.Mvc;

namespace Arkitektur.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ImagesController(IFileService _fileService) : ControllerBase
{
    [HttpPost("upload")]
    public async Task<IActionResult> FileUpload(IFormFile file)
    {
        var response = await _fileService.UploadImageToS3Async(file);
        return response.IsSuccessful ? Ok(response) : BadRequest(response);
    }
}
