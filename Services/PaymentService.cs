using Microsoft.EntityFrameworkCore;
using NWSDB.Server.Data;
using NWSDB.Server.DTOs;
using NWSDB.Server.Models;
using NWSDB.Server.Services.Exceptions;
using NWSDB.Server.Services.Interfaces;

namespace NWSDB.Server.Services;

// Shared by both the direct customer-facing PaymentsController and the
// PartnerController, so the payment rules and receipt generation live in
// exactly one place regardless of who is paying.
public class PaymentService : IPaymentService
{
    private readonly NwsdbDbContext _db;

    public PaymentService(NwsdbDbContext db)
    {
        _db = db;
    }

    public async Task<PaymentDto> CreatePaymentAsync(CreatePaymentRequestDto request, PaymentSource source)
    {
        if (request.AmountPaid <= 0)
        {
            throw new BusinessValidationException("Payment amount must be greater than zero.");
        }

        if (!Enum.TryParse<PaymentMethod>(request.PaymentMethod, ignoreCase: true, out var paymentMethod))
        {
            var validValues = string.Join(", ", Enum.GetNames<PaymentMethod>());
            throw new BusinessValidationException($"Invalid PaymentMethod '{request.PaymentMethod}'. Valid values: {validValues}.");
        }

        var customerExists = await _db.Customers.AnyAsync(c => c.CustomerId == request.CustomerId);
        if (!customerExists)
        {
            throw new NotFoundException($"Customer {request.CustomerId} was not found.");
        }

        var bill = await _db.Bills
            .Include(b => b.Payments)
            .FirstOrDefaultAsync(b => b.BillId == request.BillId)
            ?? throw new NotFoundException($"Bill {request.BillId} was not found.");

        if (bill.CustomerId != request.CustomerId)
        {
            throw new BusinessValidationException($"Bill {bill.BillId} does not belong to customer {request.CustomerId}.");
        }

        var alreadyPaid = bill.Payments.Sum(p => p.AmountPaid);
        var outstanding = bill.Amount - alreadyPaid;

        if (outstanding <= 0)
        {
            throw new ConflictException($"Bill {bill.BillId} is already fully paid.");
        }

        if (request.AmountPaid > outstanding)
        {
            throw new BusinessValidationException(
                $"Payment amount {request.AmountPaid:F2} exceeds the outstanding balance of {outstanding:F2} for bill {bill.BillId}.");
        }

        var payment = new Payment
        {
            BillId = bill.BillId,
            CustomerId = bill.CustomerId,
            AmountPaid = request.AmountPaid,
            PaymentDate = DateTime.UtcNow,
            PaymentMethod = paymentMethod,
            Source = source,
            TransactionReference = GenerateTransactionReference()
        };

        _db.Payments.Add(payment);

        var newTotalPaid = alreadyPaid + request.AmountPaid;
        bill.Status = newTotalPaid >= bill.Amount ? BillStatus.Paid : BillStatus.PartiallyPaid;

        await _db.SaveChangesAsync();

        var receipt = new PaymentReceipt
        {
            PaymentId = payment.PaymentId,
            ReceiptNumber = $"RCPT-{payment.PaymentId:D6}",
            IssuedDate = DateTime.UtcNow
        };
        _db.PaymentReceipts.Add(receipt);
        await _db.SaveChangesAsync();

        return ToDto(payment);
    }

    public async Task<List<PaymentDto>> GetPaymentHistoryAsync(int customerId)
    {
        var exists = await _db.Customers.AnyAsync(c => c.CustomerId == customerId);
        if (!exists)
        {
            throw new NotFoundException($"Customer {customerId} was not found.");
        }

        return await _db.Payments
            .AsNoTracking()
            .Where(p => p.CustomerId == customerId)
            .OrderByDescending(p => p.PaymentDate)
            .Select(p => new PaymentDto
            {
                PaymentId = p.PaymentId,
                BillId = p.BillId,
                CustomerId = p.CustomerId,
                AmountPaid = p.AmountPaid,
                PaymentDate = p.PaymentDate,
                PaymentMethod = p.PaymentMethod.ToString(),
                Source = p.Source.ToString(),
                TransactionReference = p.TransactionReference
            })
            .ToListAsync();
    }

    public async Task<PaymentReceiptDto> GetReceiptAsync(int paymentId)
    {
        var receipt = await _db.PaymentReceipts
            .Include(r => r.Payment)
            .AsNoTracking()
            .FirstOrDefaultAsync(r => r.PaymentId == paymentId)
            ?? throw new NotFoundException($"No receipt was found for payment {paymentId}.");

        var payment = receipt.Payment!;

        return new PaymentReceiptDto
        {
            ReceiptId = receipt.ReceiptId,
            ReceiptNumber = receipt.ReceiptNumber,
            IssuedDate = receipt.IssuedDate,
            PaymentId = payment.PaymentId,
            BillId = payment.BillId,
            CustomerId = payment.CustomerId,
            AmountPaid = payment.AmountPaid,
            PaymentDate = payment.PaymentDate,
            PaymentMethod = payment.PaymentMethod.ToString(),
            Source = payment.Source.ToString(),
            TransactionReference = payment.TransactionReference
        };
    }

    private static string GenerateTransactionReference()
    {
        return $"TXN-{DateTime.UtcNow:yyyyMMddHHmmss}-{Guid.NewGuid().ToString("N")[..6].ToUpperInvariant()}";
    }

    private static PaymentDto ToDto(Payment p) => new()
    {
        PaymentId = p.PaymentId,
        BillId = p.BillId,
        CustomerId = p.CustomerId,
        AmountPaid = p.AmountPaid,
        PaymentDate = p.PaymentDate,
        PaymentMethod = p.PaymentMethod.ToString(),
        Source = p.Source.ToString(),
        TransactionReference = p.TransactionReference
    };
}
