
namespace FundTransfers.BankingService.API;

public class Startup
{
    public Startup(IConfiguration configuration)
    {
        Configuration = configuration;
    }

    public IConfiguration Configuration { get; }

    // This method gets called by the runtime. Use this method to add services to the container.
    public void ConfigureServices(IServiceCollection services)
    {
        services.AddControllers();
        services.AddCustomHealthChecks();
        services.AddSwagger();

        services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
        services.AddMediatR(cfg =>
            cfg.RegisterServicesFromAssembly(typeof(FundTransfers.BankingService.Application.Dtos.BaseDto).Assembly));

        services.AddDaprClient();
        services.AddImplementations();
        //Database configuration
        services.AddDbContext<BankingContext>(options => options.UseSqlServer(Configuration.GetConnectionString("BankingDbContext")));
        services.AddRepositories();
    }

    // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
    public void Configure(IApplicationBuilder app, IWebHostEnvironment env, ILogger<Startup> logger)
    {
        if (env.IsDevelopment())
        {
            app.UseDeveloperExceptionPage();
            app.UseSwaggerEndPoints();
        }

        app.UseHttpsRedirection();
        app.UseCloudEvents();
        app.UseSerilogRequestLogging();
        app.UseRouting();
        app.UseEndpoints(endpoints =>
        {
            endpoints.MapSubscribeHandler();
            endpoints.MapControllers();
            endpoints.MapCustomHealthChecks();
        });

        if (env.IsDevelopment())
        {
            logger.LogInformation("Attempting to perform EF Core Migrations.");
            Migrate(app, logger);
        }
        else
        {
            logger.LogInformation("Not performing EF Core Migrations in environment {Environment}.", env.EnvironmentName);
        }
    }

    private static void Migrate(IApplicationBuilder app, ILogger<Startup> logger)
    {
        using var serviceScope = app.ApplicationServices.CreateScope();
        var context = serviceScope.ServiceProvider.GetService<BankingContext>();

        try
        {
            context.Database.Migrate();
        }
        catch (System.Exception ex)
        {
            logger.LogError(ex, "Exception occurred performing migration.");
        }
    }
}
