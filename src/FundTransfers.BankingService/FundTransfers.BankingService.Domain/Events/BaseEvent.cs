using System.Text.Json.Serialization;

namespace FundTransfers.BankingService.Domain.Events;

public record BaseEvent
{
    [JsonInclude]
    public Guid EventId { get; }

    [JsonInclude]
    public string EventName { get; }

    [JsonInclude]
    public DateTime CreationDate { get; }

    public BaseEvent()
    {
        EventId = Guid.NewGuid();
        EventName = GetType().Name;
        CreationDate = DateTime.UtcNow;
    }

    [JsonConstructor]
    public BaseEvent(Guid eventId, string eventName, DateTime creationDate)
    {
        EventId = eventId;
        EventName = eventName;
        CreationDate = creationDate;
    }
}
