namespace FundTransfers.BankingService.Infrastructure.Implementations;

public class DaprStateStore : IStateStore
{
    private const string DAPR_STORE_NAME = "statestore";
    private readonly DaprClient _daprClient;

    public DaprStateStore(DaprClient daprClient)
    {
        _daprClient = daprClient;
    }

    public async Task SaveStateAsync<V>(string key, V value)
    {
        await _daprClient.SaveStateAsync<V>(DAPR_STORE_NAME, key, value);
    }

    public async Task<T> GetStateAsync<T>(string key)
    {
        return await _daprClient.GetStateAsync<T>(DAPR_STORE_NAME, key);
    }
}
