using Microsoft.AspNetCore.Mvc;
using NWSDB.Server.DTOs;
using NWSDB.Server.Services.Interfaces;

namespace NWSDB.Server.Controllers;

[ApiController]
[Route("api/usage")]
public class UsageController : ControllerBase
{
    private readonly IWaterUsageService _usageService;

    public UsageController(IWaterUsageService usageService)
    {
        _usageService = usageService;
    }

    // GET /api/usage/{customerId}/current
    [HttpGet("{customerId:int}/current")]
    [ProducesResponseType(typeof(List<MeterReadingDto>), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<List<MeterReadingDto>>> GetCurrent(int customerId)
    {
        var usage = await _usageService.GetCurrentUsageAsync(customerId);
        return Ok(usage);
    }

    // GET /api/usage/{customerId}/history
    [HttpGet("{customerId:int}/history")]
    [ProducesResponseType(typeof(List<MeterReadingDto>), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<List<MeterReadingDto>>> GetHistory(int customerId)
    {
        var usage = await _usageService.GetUsageHistoryAsync(customerId);
        return Ok(usage);
    }
}
