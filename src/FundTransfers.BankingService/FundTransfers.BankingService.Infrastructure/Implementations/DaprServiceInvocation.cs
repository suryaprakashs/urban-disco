namespace FundTransfers.BankingService.Infrastructure.Implementations;

/// <inheritdoc/>
public class DaprServiceInvocation : IServiceInvocation
{
    private readonly DaprClient _daprClient;

    public DaprServiceInvocation(DaprClient daprClient)
    {
        _daprClient = daprClient ?? throw new ArgumentNullException(nameof(daprClient));
    }

    public Task<TResponse> InvokeMethodAsync<TResponse>(HttpMethod verb, string apiServiceName, string path)
    {
        return _daprClient.InvokeMethodAsync<TResponse>(verb, apiServiceName, path);
    }

    public Task<TResponse> InvokeMethodAsync<TRequest, TResponse>(HttpMethod verb, string apiServiceName, string path, TRequest data)
    {
        return _daprClient.InvokeMethodAsync<TRequest, TResponse>(verb, apiServiceName, path, data);
    }
}
