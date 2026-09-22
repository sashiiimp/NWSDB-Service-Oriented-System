using Microsoft.AspNetCore.Mvc;
using NWSDB.Server.DTOs;
using NWSDB.Server.Services.Interfaces;

namespace NWSDB.Server.Controllers;

[ApiController]
[Route("api/connections")]
public class ConnectionsController : ControllerBase
{
    private readonly ICustomerService _customerService;

    public ConnectionsController(ICustomerService customerService)
    {
        _customerService = customerService;
    }

    // GET /api/connections/customer/{customerId}
    [HttpGet("customer/{customerId:int}")]
    [ProducesResponseType(typeof(List<WaterConnectionDto>), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<List<WaterConnectionDto>>> GetByCustomer(int customerId)
    {
        var connections = await _customerService.GetConnectionsForCustomerAsync(customerId);
        return Ok(connections);
    }
}
