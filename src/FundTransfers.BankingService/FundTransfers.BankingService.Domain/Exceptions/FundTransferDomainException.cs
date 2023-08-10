namespace FundTransfers.BankingService.Domain.Exceptions;

public class FundTransferDomainException : Exception
{
    public FundTransferDomainException()
    { }

    public FundTransferDomainException(string message) : base(message)
    {
    }

    public FundTransferDomainException(string message, Exception innerException) : base(message, innerException)
    {
    }
}
