namespace FundTransfers.BankingService.Domain.SeedWork;

public interface IServiceInvocation
{
    Task<TResponse> InvokeMethodAsync<TResponse>(HttpMethod verb, string apiServiceName, string path);

    Task<TResponse> InvokeMethodAsync<TRequest, TResponse>(HttpMethod verb, string apiServiceName, string path, TRequest data);
}
