namespace FundTransfers.BankingService.Application.Commands;

public record CreateFundTransferCommand : IRequest<FundTransferDto>
{
    // Added by code generation.
    public Transaction Transaction { get; private set; }
    public TransactionStateEnum State { get; private set; }
    public CreateFundTransferCommand(Transaction transaction, TransactionStateEnum state)
    {
        Transaction = transaction;
        State = state;
    }

}