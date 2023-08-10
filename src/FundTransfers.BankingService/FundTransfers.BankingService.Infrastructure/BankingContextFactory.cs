using Microsoft.EntityFrameworkCore.Design;

namespace FundTransfers.BankingService.Infrastructure;

/// <summary>
/// Used by <c>dotnet ef</c> commands.
/// </summary>
/// <remarks>
/// This fixture accomplishes two things. Firstly, it prevents the needs to set <c>--startup-project</c>.
/// Secondly, we can set options here for migrations such as timeout that we don't want for the regular app.
/// </remarks>
public class BankingContextFactory : IDesignTimeDbContextFactory<BankingContext>
{
    public BankingContext CreateDbContext(string[] args)
    {
        var optionsBuilder = new DbContextOptionsBuilder<BankingContext>();

        optionsBuilder
            .EnableDetailedErrors()
            .EnableThreadSafetyChecks()
            .UseSqlServer(opts =>
            {
                // Set the timeout to 5 minutes
                opts.CommandTimeout((int)TimeSpan.FromMinutes(5).TotalSeconds);
                opts.EnableRetryOnFailure(
                    maxRetryCount: 10,
                    maxRetryDelay: TimeSpan.FromSeconds(30),
                    errorNumbersToAdd: null);
            });

        return new BankingContext(optionsBuilder.Options);
    }
}
