using Microsoft.AspNetCore.Mvc.ApiExplorer;

namespace FundTransfers.BankingService.API.Extensions;

/// <summary>
///   Swagger App Builder Extension
/// </summary>
public static class SwaggerAppBuilderExtension
{
    /// <summary>
    /// Adds  swagger end points for each Api Version.
    /// </summary>
    /// <param name="app">The application.</param>
    public static void UseSwaggerEndPoints(this IApplicationBuilder app)
    {
        app.UseSwagger();
        app.UseSwaggerUI(options => CreateSwaggerEndpoints(app, options));
    }

    /// <summary>
    /// Creates the swagger endpoints.
    /// </summary>
    /// <param name="app">The application.</param>
    /// <param name="options">The options.</param>
    private static void CreateSwaggerEndpoints(IApplicationBuilder app, SwaggerUIOptions options)
    {
        var apiVersionDescriptionProvider = app.ApplicationServices.GetService<IApiVersionDescriptionProvider>();

        if (apiVersionDescriptionProvider is null)
            return;

        foreach (var description in apiVersionDescriptionProvider.ApiVersionDescriptions)
        {
            options.SwaggerEndpoint($"/swagger/{description.GroupName}/swagger.json", description.GroupName.ToUpperInvariant());
        }
    }
}
