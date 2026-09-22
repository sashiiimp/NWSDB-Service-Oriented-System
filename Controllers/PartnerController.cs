using Microsoft.AspNetCore.Mvc;
using NWSDB.Server.DTOs;
using NWSDB.Server.Middleware;
using NWSDB.Server.Models;
using NWSDB.Server.Services.Interfaces;

namespace NWSDB.Server.Controllers;

// All routes under /api/partner require a valid X-Api-Key header - enforced by
// ApiKeyAuthMiddleware (registered in Program.cs for this path prefix only).
[ApiController]
[Route("api/partner")]
public class PartnerController : ControllerBase
{
    private readonly IPaymentService _paymentService;
    private readonly IBillingService _billingService;

    public PartnerController(IPaymentService paymentService, IBillingService billingService)
    {
        _paymentService = paymentService;
        _billingService = billingService;
    }

    // GET /api/partner/bills/{billId}
    // Lets a partner check the outstanding amount before submitting a payment.
    // Reuses IBillingService directly - no billing logic is duplicated here.
    [HttpGet("bills/{billId:int}")]
    [ProducesResponseType(typeof(BillDto), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<BillDto>> GetBill(int billId)
    {
        var bill = await _billingService.GetBillDetailsAsync(billId);
        return Ok(bill);
    }

    // POST /api/partner/payments
    // Reuses IPaymentService.CreatePaymentAsync - identical validation and
    // receipt generation as the customer-facing endpoint, just tagged with a
    // different PaymentSource so it's traceable back to the partner channel.
    [HttpPost("payments")]
    [ProducesResponseType(typeof(PaymentDto), StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status409Conflict)]
    public async Task<ActionResult<PaymentDto>> SubmitPayment([FromBody] CreatePaymentRequestDto request)
    {
        var payment = await _paymentService.CreatePaymentAsync(request, PaymentSource.ThirdPartyPartner);

        var partner = HttpContext.Items[ApiKeyAuthMiddleware.PartnerContextKey] as ThirdPartyPartner;
        Response.Headers.Append("X-Processed-By-Partner", partner?.PartnerName ?? "Unknown");

        return CreatedAtAction(nameof(GetBill), new { billId = payment.BillId }, payment);
    }
}
