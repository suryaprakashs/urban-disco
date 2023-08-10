namespace FundTransfers.BankingService.Infrastructure.EntityConfigurations;

public class AccountEntityTypeConfiguration
    : IEntityTypeConfiguration<Account>
{
    public void Configure(EntityTypeBuilder<Account> accountConfiguration)
    {
        accountConfiguration.ToTable("Account");

        accountConfiguration.HasKey(b => b.Id);
        accountConfiguration.Property(b => b.Id).ValueGeneratedOnAdd();

        accountConfiguration.Property(e => e.AccountType).HasConversion<int>();

    }
}
