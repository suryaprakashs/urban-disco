namespace FundTransfers.BankingService.Application.Dtos;

public record FundTransferDto : BaseDto
{
    // Added by code generation.
    public Transaction Transaction { get; set; } = default!;
    public TransactionStateEnum State { get; set; } = default!;
    public static FundTransferDto FromFundTransfer(FundTransfer fundtransfer)
    {
        return new FundTransferDto()
        {
            Transaction = fundtransfer.Transaction,
            State = fundtransfer.State,
        };
    }

}
