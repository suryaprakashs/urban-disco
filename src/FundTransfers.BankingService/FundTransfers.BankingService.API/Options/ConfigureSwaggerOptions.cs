using Microsoft.AspNetCore.Mvc.ApiExplorer;
using Microsoft.OpenApi.Models;

namespace FundTransfers.BankingService.API.Options;

/// <summary>
/// Configures the Swagger generation options.
/// </summary>
/// <remarks>This allows API versioning to define a Swagger document per API version after the
/// <see cref="IApiVersionDescriptionProvider"/> service has been resolved from the service container.</remarks>
public class ConfigureSwaggerOptions : IConfigureOptions<SwaggerGenOptions>
{
    private readonly IApiVersionDescriptionProvider provider;

    /// <summary>
    /// Initializes a new instance of the <see cref="ConfigureSwaggerOptions"/> class.
    /// </summary>
    /// <param name="provider">The <see cref="IApiVersionDescriptionProvider">provider</see> used to generate Swagger documents.</param>
    public ConfigureSwaggerOptions(IApiVersionDescriptionProvider provider) => this.provider = provider;

    /// <inheritdoc />
    public void Configure(SwaggerGenOptions options)
    {
        // add a swagger document for each discovered API version
        // note: you might choose to skip or document deprecated API versions differently
        foreach (var description in provider.ApiVersionDescriptions)
        {
            options.SwaggerDoc(description.GroupName, CreateInfoForApiVersion(description));
        }

        options.CustomOperationIds(apiDesc => apiDesc.TryGetMethodInfo(out MethodInfo methodInfo) ? methodInfo.Name : null);

        // new features

        options.ExampleFilters();

        foreach (var assembly in new[] { Assembly.GetEntryAssembly() })
        {
            var filePath = GetXmlCommentsFilePath(assembly);
            if (File.Exists(filePath))
            {
                options.IncludeXmlComments(filePath);
            }
        }
    }

    private static OpenApiInfo CreateInfoForApiVersion(ApiVersionDescription description)
    {
        //need to take these from options
        var info = new OpenApiInfo()
        {
            Title = "Inizio - ASP.NET Core Web API (Domain-Driven-Design)",
            Version = description.ApiVersion.ToString(),
            Description = "FundTransfers is a ASP.NET Core Web API project designed using DDD (Domain Driven Design) approach."
        };

        if (description.IsDeprecated)
        {
            info.Description += " This API version has been deprecated.";
        }

        return info;
    }

    /// <summary>
    /// The Get Xml Comments FilePath.
    /// </summary>
    /// <param name="assembly">The assembly<see cref="Assembly"/>.</param>
    /// <returns>The <see cref="string"/>.</returns>
    private static string GetXmlCommentsFilePath(Assembly assembly)
    {
        var basePath = AppContext.BaseDirectory;
        var fileName = $"{assembly.GetName().Name}.xml";
        return Path.Combine(basePath, fileName);
    }
}
