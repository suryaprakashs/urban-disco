using Dapr.Client;
using Dapr.Extensions.Configuration;

namespace FundTransfers.BankingService.API;

public class Program
{
    public static int Main(string[] args)
    {
        Log.Logger = new LoggerConfiguration()
                    .MinimumLevel.Information()
                    .MinimumLevel.Override("Microsoft", LogEventLevel.Information)
                    .MinimumLevel.Override("Microsoft.AspNetCore", LogEventLevel.Warning)
                    .Enrich.FromLogContext()
                    .WriteTo.Console()
                    .CreateLogger();

        try
        {
            Log.Information("Starting web host");
            CreateHostBuilder(args).Build().Run();
            return 0;
        }
        catch (Exception ex)
        {
            Log.Fatal(ex, "Host terminated unexpectedly");
            return 1;
        }
        finally
        {
            Log.CloseAndFlush();
        }
    }

    public static IHostBuilder CreateHostBuilder(string[] args)
    {
        var hostBuilder = Host.CreateDefaultBuilder(args)
                            .UseSerilog()
                            .ConfigureWebHostDefaults(webBuilder =>
                            {
                                webBuilder.UseStartup<Startup>();
                            }).ConfigureAppConfiguration((context, configurationBuilder) =>
                            {
                                if (!context.HostingEnvironment.IsDevelopment())
                                {
                                var daprClient = new DaprClientBuilder().Build();
                                configurationBuilder.AddDaprSecretStore("secret-store", daprClient, TimeSpan.FromSeconds(20));
                                configurationBuilder.AddDaprConfigurationStore("config-store", new List<string>() { }, daprClient, TimeSpan.FromSeconds(20));
                                // config.AddStreamingDaprConfigurationStore("config-store", new List<string>() { }, daprClient, TimeSpan.FromSeconds(20));
                                }
                            });

        return hostBuilder;
    }
}
