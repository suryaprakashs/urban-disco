using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Versioning;

namespace FundTransfers.BankingService.API.Extensions;

public static class ServiceCollectionExtensions
{
    public static void AddSwagger(this IServiceCollection services)
    {
        services.AddCustomApiVersioning();
        services.AddSwaggerGen();
        services.AddTransient<IConfigureOptions<SwaggerGenOptions>, ConfigureSwaggerOptions>();
        services.AddSwaggerExamplesFromAssemblies(Assembly.GetEntryAssembly());
    }

    public static void AddImplementations(this IServiceCollection services)
    {
        services.AddSingleton<IServiceInvocation, DaprServiceInvocation>();
        services.AddSingleton<IStateStore, DaprStateStore>();
        services.AddSingleton<IEventBus, DaprEventBus>();
    }



    /// <summary>
    /// Adds the custom API versioning.
    /// </summary>
    /// <param name="services">The services.</param>
    public static void AddCustomApiVersioning(this IServiceCollection services)
    {
        services.AddApiVersioning(config =>
        {
            config.DefaultApiVersion = new ApiVersion(1, 0);
            config.AssumeDefaultVersionWhenUnspecified = true;
            config.ReportApiVersions = true;
            config.ApiVersionReader = ApiVersionReader.Combine(new UrlSegmentApiVersionReader(), new HeaderApiVersionReader("api-version"));
        });

        services.AddVersionedApiExplorer(
            options =>
            {
                // note: the specified format code will format the version as "'v'major[.minor][-status]
                options.GroupNameFormat = "'v'VVV";
                options.SubstituteApiVersionInUrl = true;
            });
    }
}
