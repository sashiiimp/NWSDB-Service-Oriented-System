using Microsoft.AspNetCore.Mvc;
using NWSDB.Server.DTOs;
using NWSDB.Server.Models;
using NWSDB.Server.Services.Interfaces;

namespace NWSDB.Server.Controllers;

[ApiController]
[Route("api/payments")]
public class PaymentsController : ControllerBase
{
    private readonly IPaymentService _paymentService;

    public PaymentsController(IPaymentService paymentService)
    {
        _paymentService = paymentService;
    }

    // POST /api/payments
    [HttpPost]
    [ProducesResponseType(typeof(PaymentDto), StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status409Conflict)]
    public async Task<ActionResult<PaymentDto>> Create([FromBody] CreatePaymentRequestDto request)
    {
        // Direct customer/admin-office payments; partner payments go through
        // PartnerController, which calls the same service with a different source.
        var payment = await _paymentService.CreatePaymentAsync(request, PaymentSource.CustomerPortal);
        return CreatedAtAction(nameof(GetReceipt), new { paymentId = payment.PaymentId }, payment);
    }

    // GET /api/payments/{customerId}/history
    [HttpGet("{customerId:int}/history")]
    [ProducesResponseType(typeof(List<PaymentDto>), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<List<PaymentDto>>> GetHistory(int customerId)
    {
        var payments = await _paymentService.GetPaymentHistoryAsync(customerId);
        return Ok(payments);
    }

    // GET /api/payments/{paymentId}/receipt
    [HttpGet("{paymentId:int}/receipt")]
    [ProducesResponseType(typeof(PaymentReceiptDto), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<PaymentReceiptDto>> GetReceipt(int paymentId)
    {
        var receipt = await _paymentService.GetReceiptAsync(paymentId);
        return Ok(receipt);
    }
}
