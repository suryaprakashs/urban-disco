using Microsoft.Extensions.Diagnostics.HealthChecks;

namespace FundTransfers.BankingService.API.Extensions;

public static class HealthCheckBuilderExtension
{
    public static void AddCustomHealthChecks(this IServiceCollection services)
    {
        services.AddHealthChecks()
            .AddCheck<CustomHealthCheck>("custom");
    }

    public static void MapCustomHealthChecks(this IEndpointRouteBuilder endpoints)
    {
        endpoints.MapHealthChecks("/healthz");
        endpoints.MapHealthChecks("/ready");
    }

    public class CustomHealthCheck : IHealthCheck
    {
        public Task<HealthCheckResult> CheckHealthAsync(
            HealthCheckContext context,
            CancellationToken cancellationToken = default)
        {
            // Place your own implemenation for the definition of Healthy or Unhealthy.
            // var result = HealthCheckResult.Unhealthy("Failed");
            var result = HealthCheckResult.Healthy();

            return Task.FromResult(result);
        }
    }
}
