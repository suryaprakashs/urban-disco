using Microsoft.AspNetCore.Mvc;
using Dapr;

namespace FundTransfers.BankingService.API.Controllers;

/// <summary>
/// State Controller
/// Note: These are reference controllers and shouldn't be exposed in production version
/// </summary>
[Route("api/[controller]")]
[ApiController]
[ApiVersion("1.0")]
public class StateController : ControllerBase
{
    private readonly IStateStore _stateStore;

    public StateController(
        IStateStore stateStore)
    {
        _stateStore = stateStore;
    }

    [HttpGet("get-state/{key}")]
    public async Task<ActionResult> GetState(string key)
    {
        // Returns the state of the given key, if found. Default value if not.
        var result = await _stateStore.GetStateAsync<string>(key);
        return Ok(result);
    }

    [HttpGet("save-state/{key}/{value}")]
    public async Task<ActionResult> SaveState(string key, string value)
    {
        // Saves the state for the given key value pair.
        await _stateStore.SaveStateAsync<string>(key, value);
        return Ok(value);
    }
}
