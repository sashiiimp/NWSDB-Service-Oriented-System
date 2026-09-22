using Microsoft.EntityFrameworkCore;
using NWSDB.Server.Data;
using NWSDB.Server.DTOs;
using NWSDB.Server.Models;
using NWSDB.Server.Services.Exceptions;
using NWSDB.Server.Services.Interfaces;

namespace NWSDB.Server.Services;

public class BillingService : IBillingService
{
    private readonly NwsdbDbContext _db;

    public BillingService(NwsdbDbContext db)
    {
        _db = db;
    }

    // "Current" bill = the most recent outstanding (not fully paid) bill, falling
    // back to the most recently issued bill if everything is already paid.
    public async Task<BillDto> GetCurrentBillAsync(int customerId)
    {
        await EnsureCustomerExists(customerId);

        var bill = await _db.Bills
            .Include(b => b.Payments)
            .AsNoTracking()
            .Where(b => b.CustomerId == customerId && b.Status != BillStatus.Paid)
            .OrderByDescending(b => b.IssuedDate)
            .FirstOrDefaultAsync();

        bill ??= await _db.Bills
            .Include(b => b.Payments)
            .AsNoTracking()
            .Where(b => b.CustomerId == customerId)
            .OrderByDescending(b => b.IssuedDate)
            .FirstOrDefaultAsync();

        if (bill is null)
        {
            throw new NotFoundException($"Customer {customerId} has no bills.");
        }

        return ToDto(bill);
    }

    public async Task<List<BillDto>> GetBillHistoryAsync(int customerId)
    {
        await EnsureCustomerExists(customerId);

        var bills = await _db.Bills
            .Include(b => b.Payments)
            .AsNoTracking()
            .Where(b => b.CustomerId == customerId)
            .OrderByDescending(b => b.IssuedDate)
            .ToListAsync();

        return bills.Select(ToDto).ToList();
    }

    public async Task<BillDto> GetBillDetailsAsync(int billId)
    {
        var bill = await _db.Bills
            .Include(b => b.Payments)
            .AsNoTracking()
            .FirstOrDefaultAsync(b => b.BillId == billId)
            ?? throw new NotFoundException($"Bill {billId} was not found.");

        return ToDto(bill);
    }

    private async Task EnsureCustomerExists(int customerId)
    {
        var exists = await _db.Customers.AnyAsync(c => c.CustomerId == customerId);
        if (!exists)
        {
            throw new NotFoundException($"Customer {customerId} was not found.");
        }
    }

    internal static BillDto ToDto(Bill bill)
    {
        var amountPaid = bill.Payments.Sum(p => p.AmountPaid);
        return new BillDto
        {
            BillId = bill.BillId,
            CustomerId = bill.CustomerId,
            ConnectionId = bill.ConnectionId,
            BillingPeriodStart = bill.BillingPeriodStart,
            BillingPeriodEnd = bill.BillingPeriodEnd,
            UnitsConsumed = bill.UnitsConsumed,
            Amount = bill.Amount,
            AmountPaid = amountPaid,
            OutstandingAmount = bill.Amount - amountPaid,
            IssuedDate = bill.IssuedDate,
            DueDate = bill.DueDate,
            Status = bill.Status.ToString()
        };
    }
}
