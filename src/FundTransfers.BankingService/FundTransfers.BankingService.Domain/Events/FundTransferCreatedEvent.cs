namespace FundTransfers.BankingService.Domain.Events;

public record FundTransferCreatedEvent(int id, Transaction transaction, TransactionStateEnum state)
    : BaseEvent;
