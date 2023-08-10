using Microsoft.AspNetCore.Mvc;
using Dapr;

namespace FundTransfers.BankingService.API.Controllers;

/// <summary>
/// Configuration Controller
/// Note: These are reference controllers and shouldn't be exposed in production version
/// </summary>
[Route("api/[controller]")]
[ApiController]
[ApiVersion("1.0")]
public class ConfigurationController : ControllerBase
{
    private readonly IConfiguration _configuration;

    public ConfigurationController(IConfiguration configuration)
    {
        _configuration = configuration;
    }

    [HttpGet("get-secret")]
    public ActionResult GetSecret()
    {
        // Dapr supported secret stores have been registered to the configuration.
        return Ok(_configuration["demo-secret"]);
    }

    [HttpGet("get-config")]
    public ActionResult GetConfig()
    {
        // Dapr supported config stores have been registered to the configuration.
        return Ok(_configuration["demoConfig"]);
    }
}
