using Microsoft.AspNetCore.Mvc;

namespace JacoApi.Controllers;

[ApiController]
[Route("[controller]")]
public class JacoController : ControllerBase
{
    private readonly ILogger<JacoController> _logger;

    public JacoController(ILogger<JacoController> logger)
    {
        _logger = logger;
    }

    [HttpGet(Name = "Jaco")]
    public IActionResult Get()
    {
        _logger.LogInformation("Jaco API was called");
        return new OkObjectResult("Hello from Jaco API!");
    }
}
