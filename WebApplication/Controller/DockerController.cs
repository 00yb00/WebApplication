using BLL.Services.Implementations;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

[ApiController]
[Route("api/[controller]")]
public class DockerController : ControllerBase
{
    private readonly DockerService _dockerService;

    public DockerController(DockerService dockerService)
    {
        _dockerService = dockerService;
    }

    [HttpPost("start")]
    public async Task<IActionResult> StartCompose([FromQuery] string fileName)
    {
        string filePath = $"D:\\נסיונות פיתוח\\Northwind web application\\WebApplication/{fileName}";

        // ניתן להוסיף כאן בדיקה שהקובץ קיים
        var result = await _dockerService.RunComposeUpAsync(filePath);

        if (result.StartsWith("Error"))
            return BadRequest(result);

        return Ok(result);
    }

    [HttpPost("stop")]
    public async Task<IActionResult> StopCompose([FromQuery] string fileName)
    {
        string filePath = $"D:\\נסיונות פיתוח\\Northwind web application\\WebApplication/{fileName}";

        var result = await _dockerService.RunComposeDownAsync(filePath);

        if (result.StartsWith("Error"))
            return BadRequest(result);

        return Ok(result);
    }
}
