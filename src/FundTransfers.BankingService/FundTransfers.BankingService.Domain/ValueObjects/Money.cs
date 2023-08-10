namespace FundTransfers.BankingService.Domain.AggregatesModel;

public class Money : ValueObject
{
    // Added by code generation.
    public string CurrencyType { get; set; }
    public float Amount { get; set; }
    public Money() { }

    protected override IEnumerable<object> GetEqualityComponents()
    {
        throw new NotImplementedException();
    }
    
}
