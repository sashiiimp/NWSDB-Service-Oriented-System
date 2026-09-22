using Microsoft.AspNetCore.Mvc;
using NWSDB.Server.DTOs;
using NWSDB.Server.Services.Interfaces;

namespace NWSDB.Server.Controllers;

[ApiController]
[Route("api/bills")]
public class BillsController : ControllerBase
{
    private readonly IBillingService _billingService;

    public BillsController(IBillingService billingService)
    {
        _billingService = billingService;
    }

    // GET /api/bills/{customerId}/current
    [HttpGet("{customerId:int}/current")]
    [ProducesResponseType(typeof(BillDto), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<BillDto>> GetCurrent(int customerId)
    {
        var bill = await _billingService.GetCurrentBillAsync(customerId);
        return Ok(bill);
    }

    // GET /api/bills/{customerId}/history
    [HttpGet("{customerId:int}/history")]
    [ProducesResponseType(typeof(List<BillDto>), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<List<BillDto>>> GetHistory(int customerId)
    {
        var bills = await _billingService.GetBillHistoryAsync(customerId);
        return Ok(bills);
    }

    // GET /api/bills/details/{billId}
    [HttpGet("details/{billId:int}")]
    [ProducesResponseType(typeof(BillDto), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<BillDto>> GetDetails(int billId)
    {
        var bill = await _billingService.GetBillDetailsAsync(billId);
        return Ok(bill);
    }
}
