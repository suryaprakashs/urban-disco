using Microsoft.AspNetCore.Mvc;
using Dapr;

namespace FundTransfers.BankingService.API.Controllers;

/// <summary>
/// Event Bus Controller
/// Note: These are reference controllers and shouldn't be exposed in production version
/// </summary>
[Route("api/[controller]")]
[ApiController]
[ApiVersion("1.0")]
public class EventBusController : ControllerBase
{
    private readonly IEventBus _eventBus;
    private readonly IStateStore _stateStore;

    public EventBusController(
        IEventBus eventBus,
        IStateStore stateStore)
    {
        _eventBus = eventBus;
        _stateStore = stateStore;
    }

    [HttpGet("publish-demo-event")]
    public async Task<ActionResult> PublishDemoEvent()
    {
        // Publishes a demo event.
        var baseEvent = new DemoCreatedEvent(1008, "Hello from demo controller!!! Pub/Sub is Working.");
         await _eventBus.PublishAsync("banking-topic", baseEvent);
        return Ok(baseEvent);
    }

    [HttpGet("get-demo-event")]
    public async Task<ActionResult> GetDemoEvent()
    {
        // Reads demo event from state and returns to the user when user makes a call.
        var result = await _stateStore.GetStateAsync<DemoCreatedEvent>("democreatedevent");
        return Ok(result);
    }


    [Topic("pubsub", "banking-topic")]
    [HttpPost("subscribe-demo-event")]
    public async Task<ActionResult> SubscribeDemoEvent(DemoCreatedEvent baseEvent)
    {
        // Subscribe to the 'banking-topic' and hold the 'demoevent' in the dapr state.
        await _stateStore.SaveStateAsync<DemoCreatedEvent>("democreatedevent", baseEvent);
        return Ok();
    }
}
