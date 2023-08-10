namespace FundTransfers.BankingService.Domain.AggregatesModel;

public class Account : Entity
{
    // Added by code generation.
    public string AccountName { get; set; } = default!;
    public string AccountNumber { get; set; } = default!;
    public AccountTypeEnum? AccountType { get; set; } = default!;
    public float Balance { get; set; } = default!;
    public List<string>? TransactionHistory { get; set; } = default!;

    

    public string GetAccountName()
    {
        throw new NotImplementedException();
    }

}
