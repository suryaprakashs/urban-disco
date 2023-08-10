namespace FundTransfers.BankingService.Domain.AggregatesModel;

public class TransactionDetails : ValueObject
{
    // Added by code generation.
    public int TransactionId { get; set; }
    public TransactionTypeEnum TransactionType { get; set; }
    public string Notes { get; set; }
    public Money? TransactionAmount { get; set; }
    public TransactionDetails() { }

    protected override IEnumerable<object> GetEqualityComponents()
    {
        throw new NotImplementedException();
    }
    

    public float GetBalance(int transactionId)
    {
        throw new NotImplementedException();
    }

}
