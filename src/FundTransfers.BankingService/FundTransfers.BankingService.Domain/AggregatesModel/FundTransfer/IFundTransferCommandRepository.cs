namespace FundTransfers.BankingService.Domain.AggregatesModel;

public interface IFundTransferCommandRepository : IRepository<FundTransfer>
{
    Task<FundTransfer> AddAsync(FundTransfer fundtransfer, CancellationToken token);

    void Update(FundTransfer fundtransfer);

    Task Remove(int fundtransferId);
}
