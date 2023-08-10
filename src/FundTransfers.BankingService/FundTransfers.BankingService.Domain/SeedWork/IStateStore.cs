namespace FundTransfers.BankingService.Domain.SeedWork;

public interface IStateStore
{
    Task SaveStateAsync<V>(string key, V value);
    Task<T> GetStateAsync<T>(string key);
}
