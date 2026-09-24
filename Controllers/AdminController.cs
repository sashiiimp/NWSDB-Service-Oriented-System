using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using NWSDB.Server.DTOs;
using NWSDB.Server.Services;
using NWSDB.Server.Services.Interfaces;

namespace NWSDB.Server.Controllers;

// NWSDB Admin actor. Login is anonymous and returns a JWT; every other route
// requires "Authorization: Bearer <token>" for a user in the Admin role.
[ApiController]
[Route("api/admin")]
[Authorize(Roles = AdminService.AdminRole)]
public class AdminController : ControllerBase
{
    private readonly IAdminService _adminService;

    public AdminController(IAdminService adminService)
    {
        _adminService = adminService;
    }

    // POST /api/admin/login
    [HttpPost("login")]
    [AllowAnonymous]
    [ProducesResponseType(typeof(AdminLoginResponseDto), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    public async Task<ActionResult<AdminLoginResponseDto>> Login([FromBody] AdminLoginRequestDto request)
    {
        var result = await _adminService.LoginAsync(request);
        if (result is null)
        {
            // Same { status, error } shape as ExceptionHandlingMiddleware.
            return Unauthorized(new { status = StatusCodes.Status401Unauthorized, error = "Invalid username or password." });
        }

        return Ok(result);
    }

    // GET /api/admin/customers
    [HttpGet("customers")]
    [ProducesResponseType(typeof(List<AdminCustomerDto>), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    public async Task<ActionResult<List<AdminCustomerDto>>> GetCustomers()
    {
        return Ok(await _adminService.GetCustomersAsync());
    }

    // GET /api/admin/connections
    [HttpGet("connections")]
    [ProducesResponseType(typeof(List<AdminConnectionDto>), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    public async Task<ActionResult<List<AdminConnectionDto>>> GetConnections()
    {
        return Ok(await _adminService.GetConnectionsAsync());
    }

    // POST /api/admin/meter-readings
    [HttpPost("meter-readings")]
    [ProducesResponseType(typeof(MeterReadingDto), StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status409Conflict)]
    public async Task<ActionResult<MeterReadingDto>> RecordMeterReading([FromBody] CreateMeterReadingRequestDto request)
    {
        var reading = await _adminService.RecordMeterReadingAsync(request);
        return StatusCode(StatusCodes.Status201Created, reading);
    }

    // POST /api/admin/bills
    [HttpPost("bills")]
    [ProducesResponseType(typeof(BillDto), StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status409Conflict)]
    public async Task<ActionResult<BillDto>> GenerateBill([FromBody] GenerateBillRequestDto request)
    {
        var bill = await _adminService.GenerateBillAsync(request);
        // Points at the existing GET /api/bills/details/{billId}.
        return CreatedAtAction(nameof(BillsController.GetDetails), "Bills", new { billId = bill.BillId }, bill);
    }
}
