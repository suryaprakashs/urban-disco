using FundTransfers.BankingService.Domain.Events;

namespace FundTransfers.BankingService.Domain.SeedWork;

public interface IEventBus
{
    Task PublishAsync<T>(string topicName, T integrationEvent)
        where T : BaseEvent;
}
