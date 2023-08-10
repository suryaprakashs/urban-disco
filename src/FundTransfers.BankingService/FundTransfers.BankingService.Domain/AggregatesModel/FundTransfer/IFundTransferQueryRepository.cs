namespace FundTransfers.BankingService.Domain.AggregatesModel;

public interface IFundTransferQueryRepository : IRepository<FundTransfer>
{
    Task<IEnumerable<FundTransfer>> GetAsync();
    
    Task<FundTransfer> GetAsync(int fundtransferId);
}
