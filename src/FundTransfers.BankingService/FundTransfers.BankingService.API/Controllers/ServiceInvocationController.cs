using Microsoft.AspNetCore.Mvc;
using Dapr;

namespace FundTransfers.BankingService.API.Controllers;

/// <summary>
/// Service Invocation Controller
/// Note: These are reference controllers and shouldn't be exposed in production version
/// </summary>
[Route("api/[controller]")]
[ApiController]
[ApiVersion("1.0")]
public class ServiceInvocationController : ControllerBase
{
    private readonly IServiceInvocation _serviceInvocation;

    public ServiceInvocationController(IServiceInvocation serviceInvocation)
    {
        _serviceInvocation = serviceInvocation;
    }

    [HttpGet("invoke-service")]
    public ActionResult InvokeCurrentService()
    {
        // Normal get call returns hello.
        return Ok(new ResultModel { Result = "Hello from banking service!" });
    }

    [HttpGet("invoke-service/{apiservicename}")]
    public async Task<ActionResult> InvokeOtherService(string apiservicename)
    {
        // This makes get call to the "invoke-service" of the given service. ie., {apiservicename}.
        var result = await _serviceInvocation.InvokeMethodAsync<ResultModel>(HttpMethod.Get, apiservicename, "/api/serviceinvocation/invoke-service");
        return Ok(result);
    }

    public class ResultModel
    {
        public string Result { get; set; }
    }
}
