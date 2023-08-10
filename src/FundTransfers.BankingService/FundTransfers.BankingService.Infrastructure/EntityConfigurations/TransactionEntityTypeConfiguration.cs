namespace FundTransfers.BankingService.Infrastructure.EntityConfigurations;

public class TransactionEntityTypeConfiguration
    : IEntityTypeConfiguration<Transaction>
{
    public void Configure(EntityTypeBuilder<Transaction> transactionConfiguration)
    {
        transactionConfiguration.ToTable("Transaction");

        transactionConfiguration.HasKey(b => b.Id);
        transactionConfiguration.Property(b => b.Id).ValueGeneratedOnAdd();


        transactionConfiguration.OwnsOne(o => o.TransactionDetails, transactiondetailsConfiguration =>
        {
            transactiondetailsConfiguration.Property(e => e.TransactionType).HasConversion<int>();

            transactiondetailsConfiguration.OwnsOne(o => o.TransactionAmount, transactionamountConfiguration =>
            {

            });
            transactiondetailsConfiguration.Navigation(x => x.TransactionAmount).IsRequired();

        });
        transactionConfiguration.Navigation(x => x.TransactionDetails).IsRequired();

    }
}
