using System.Text.Json.Serialization;

namespace FundTransfers.BankingService.Domain.Events;

public record DemoCreatedEvent
: BaseEvent
{
    [JsonInclude]
    public int Id { get; }

    [JsonInclude]
    public string Message { get; }

    public DemoCreatedEvent(int id, string message)
    {
        Id = id;
        Message = message;
    }
}
