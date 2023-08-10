using FundTransfers.BankingService.Domain.Events;

namespace FundTransfers.BankingService.Infrastructure.Implementations;

/// <inheritdoc/>
public class DaprEventBus : IEventBus
{
    // This is the name of the Dapr pubsub component
    private const string PubSubName = "pubsub";

    private readonly DaprClient _dapr;

    public DaprEventBus(DaprClient dapr)
    {
        _dapr = dapr ?? throw new ArgumentNullException(nameof(dapr));
    }

    public async Task PublishAsync<T>(string topicName, T integrationEvent)
        where T : BaseEvent
    {
        await _dapr.PublishEventAsync<T>(PubSubName, topicName, integrationEvent);
    }
}
