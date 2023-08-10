namespace FundTransfers.BankingService.Domain.AggregatesModel;

public class FundTransfer : Entity, IAggregateRoot
{
    // Added by code generation.
    public Transaction Transaction { get; set; }
    public TransactionStateEnum State { get; set; }
    public FundTransfer(Transaction transaction, TransactionStateEnum state)
    {
        Transaction = transaction;
        State = state;
    }


    public FundTransfer()
    {
    }
    

    public bool Remove(int transactionId)
    {
        throw new NotImplementedException();
    }


    public Transaction GetTransaction(int transactionId)
    {
        throw new NotImplementedException();
    }

}
