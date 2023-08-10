namespace FundTransfers.BankingService.Infrastructure.EntityConfigurations;

public class FundTransferEntityTypeConfiguration
    : IEntityTypeConfiguration<FundTransfer>
{
    public void Configure(EntityTypeBuilder<FundTransfer> fundtransferConfiguration)
    {
        fundtransferConfiguration.ToTable("FundTransfer");

        fundtransferConfiguration.HasKey(b => b.Id);
        fundtransferConfiguration.Property(b => b.Id).ValueGeneratedOnAdd();

        fundtransferConfiguration.Property(e => e.State).HasConversion<int>();

    }
}
