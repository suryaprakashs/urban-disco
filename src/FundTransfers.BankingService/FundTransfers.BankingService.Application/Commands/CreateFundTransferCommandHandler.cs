namespace FundTransfers.BankingService.Application.Commands;

public class CreateFundTransferCommandHandler : IRequestHandler<CreateFundTransferCommand, FundTransferDto>
{
    public const string FundTransferTopic = "fundtransfer-topic";

    private readonly IEventBus _eventBus;

    public CreateFundTransferCommandHandler(
        IEventBus eventBus
        )
    {
        _eventBus = eventBus ?? throw new ArgumentNullException(nameof(eventBus));
    }

    public async Task<FundTransferDto> Handle(CreateFundTransferCommand request, CancellationToken cancellationToken)
    {
        var fundtransfer = new FundTransfer(request.Transaction, request.State);

        await _eventBus.PublishAsync(FundTransferTopic, new FundTransferCreatedEvent(fundtransfer.Id, fundtransfer.Transaction, fundtransfer.State));

        return FundTransferDto.FromFundTransfer(fundtransfer);
    }
}
