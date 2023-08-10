namespace FundTransfers.BankingService.Domain.AggregatesModel;

public class Transaction : Entity
{
    // Added by code generation.
    public TransactionDetails TransactionDetails { get; set; } = default!;
    public Account? SourceAccount { get; set; } = default!;
    public Account? DestinationAccount { get; set; } = default!;
    public DateTime TransactionTime { get; set; } = default!;

    
}
