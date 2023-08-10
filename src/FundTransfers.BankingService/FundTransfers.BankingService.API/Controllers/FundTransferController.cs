using Microsoft.AspNetCore.Mvc;

namespace FundTransfers.BankingService.API.Controllers;

[Route("api/[controller]")]
[ApiController]
[ApiVersion("1.0")]
public class FundTransferController : ControllerBase
{
    private readonly IMediator _mediator;

    public FundTransferController(
        IMediator mediator
        )
    {
        _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
    }

    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public async Task<ActionResult> GetFundTransferAsync()
    {
        return Ok();
    }

    [HttpGet("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(FundTransferDto))]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult> GetFundTransferByIdAsync(int id)
    {
        return Ok();
    }

    [HttpPost]
    public async Task<ActionResult<FundTransferDto>> CreateFundTransfer([FromBody] CreateFundTransferCommand createFundTransferCommand)
    {
        return await _mediator.Send(createFundTransferCommand);
    }
}
