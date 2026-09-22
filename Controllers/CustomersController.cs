using Microsoft.AspNetCore.Mvc;
using NWSDB.Server.DTOs;
using NWSDB.Server.Services.Interfaces;

namespace NWSDB.Server.Controllers;

[ApiController]
[Route("api/customers")]
public class CustomersController : ControllerBase
{
    private readonly ICustomerService _customerService;

    public CustomersController(ICustomerService customerService)
    {
        _customerService = customerService;
    }

    // GET /api/customers/{id}
    [HttpGet("{id:int}")]
    [ProducesResponseType(typeof(CustomerDto), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<CustomerDto>> GetById(int id)
    {
        var customer = await _customerService.GetByIdAsync(id);
        return Ok(customer);
    }

    // GET /api/customers/account/{accountNumber}
    [HttpGet("account/{accountNumber}")]
    [ProducesResponseType(typeof(CustomerDto), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<CustomerDto>> GetByAccountNumber(string accountNumber)
    {
        var customer = await _customerService.GetByAccountNumberAsync(accountNumber);
        return Ok(customer);
    }
}
