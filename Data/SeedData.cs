using Microsoft.EntityFrameworkCore;
using NWSDB.Server.Models;

namespace NWSDB.Server.Data;

// Small, fully fictional demo dataset (per assignment requirements: no real
// NWSDB customer data). Runs once on startup, only when the Customers table
// is empty, so re-running the app never duplicates rows.
public static class SeedData
{
    public static async Task SeedAsync(NwsdbDbContext context)
    {
        if (await context.Customers.AnyAsync())
        {
            return;
        }

        var customer1 = new Customer
        {
            AccountNumber = "NW-100001",
            FullName = "Kasun Perera",
            Email = "kasun.perera@example.com",
            Phone = "0771234501",
            Address = "12 Lake Road, Colombo 05"
        };
        var customer2 = new Customer
        {
            AccountNumber = "NW-100002",
            FullName = "Nadeesha Silva",
            Email = "nadeesha.silva@example.com",
            Phone = "0771234502",
            Address = "45 Galle Road, Mount Lavinia"
        };
        var customer3 = new Customer
        {
            AccountNumber = "NW-100003",
            FullName = "Ruwan Fernando",
            Email = "ruwan.fernando@example.com",
            Phone = "0771234503",
            Address = "8 Kandy Road, Kadawata"
        };
        context.Customers.AddRange(customer1, customer2, customer3);
        await context.SaveChangesAsync();

        var conn1001 = new WaterConnection
        {
            CustomerId = customer1.CustomerId,
            ConnectionNumber = "CONN-1001",
            ConnectionAddress = "12 Lake Road, Colombo 05",
            Status = ConnectionStatus.Active
        };
        var conn1002 = new WaterConnection
        {
            CustomerId = customer2.CustomerId,
            ConnectionNumber = "CONN-1002",
            ConnectionAddress = "45 Galle Road, Mount Lavinia",
            Status = ConnectionStatus.Active
        };
        var conn1003 = new WaterConnection
        {
            CustomerId = customer3.CustomerId,
            ConnectionNumber = "CONN-1003",
            ConnectionAddress = "8 Kandy Road, Kadawata",
            Status = ConnectionStatus.Active
        };
        var conn1004 = new WaterConnection
        {
            CustomerId = customer3.CustomerId,
            ConnectionNumber = "CONN-1004",
            ConnectionAddress = "22 Negombo Road, Wattala (Business)",
            Status = ConnectionStatus.Active
        };
        context.WaterConnections.AddRange(conn1001, conn1002, conn1003, conn1004);
        await context.SaveChangesAsync();

        var readings = new List<MeterReading>
        {
            Reading(conn1001.ConnectionId, new DateTime(2026, 6, 15), 1000, 1050),
            Reading(conn1001.ConnectionId, new DateTime(2026, 7, 15), 1050, 1105),
            Reading(conn1001.ConnectionId, new DateTime(2026, 8, 15), 1105, 1160),
            Reading(conn1001.ConnectionId, new DateTime(2026, 9, 15), 1160, 1220),

            Reading(conn1002.ConnectionId, new DateTime(2026, 6, 10), 500, 540),
            Reading(conn1002.ConnectionId, new DateTime(2026, 7, 10), 540, 585),
            Reading(conn1002.ConnectionId, new DateTime(2026, 8, 10), 585, 625),
            Reading(conn1002.ConnectionId, new DateTime(2026, 9, 10), 625, 670),

            Reading(conn1003.ConnectionId, new DateTime(2026, 7, 1), 200, 230),
            Reading(conn1003.ConnectionId, new DateTime(2026, 8, 1), 230, 265),
            Reading(conn1003.ConnectionId, new DateTime(2026, 9, 1), 265, 300),

            Reading(conn1004.ConnectionId, new DateTime(2026, 7, 5), 5000, 5150),
            Reading(conn1004.ConnectionId, new DateTime(2026, 8, 5), 5150, 5310),
            Reading(conn1004.ConnectionId, new DateTime(2026, 9, 5), 5310, 5480),
        };
        context.MeterReadings.AddRange(readings);
        await context.SaveChangesAsync();

        const decimal ratePerUnit = 100m;

        var bill1Paid = Bill(customer1.CustomerId, conn1001.ConnectionId,
            new DateTime(2026, 7, 16), new DateTime(2026, 8, 15), 55,
            new DateTime(2026, 8, 16), new DateTime(2026, 8, 31), BillStatus.Paid, ratePerUnit);
        var bill1Current = Bill(customer1.CustomerId, conn1001.ConnectionId,
            new DateTime(2026, 8, 16), new DateTime(2026, 9, 15), 60,
            new DateTime(2026, 9, 16), new DateTime(2026, 9, 30), BillStatus.Unpaid, ratePerUnit);

        var bill2Paid = Bill(customer2.CustomerId, conn1002.ConnectionId,
            new DateTime(2026, 7, 11), new DateTime(2026, 8, 10), 40,
            new DateTime(2026, 8, 11), new DateTime(2026, 8, 26), BillStatus.Paid, ratePerUnit);
        var bill2Partial = Bill(customer2.CustomerId, conn1002.ConnectionId,
            new DateTime(2026, 8, 11), new DateTime(2026, 9, 10), 45,
            new DateTime(2026, 9, 11), new DateTime(2026, 9, 26), BillStatus.PartiallyPaid, ratePerUnit);

        var bill3aPaid = Bill(customer3.CustomerId, conn1003.ConnectionId,
            new DateTime(2026, 7, 2), new DateTime(2026, 8, 1), 35,
            new DateTime(2026, 8, 2), new DateTime(2026, 8, 17), BillStatus.Paid, ratePerUnit);
        var bill3aOverdue = Bill(customer3.CustomerId, conn1003.ConnectionId,
            new DateTime(2026, 8, 2), new DateTime(2026, 9, 1), 35,
            new DateTime(2026, 9, 2), new DateTime(2026, 9, 17), BillStatus.Overdue, ratePerUnit);

        var bill3bPaid = Bill(customer3.CustomerId, conn1004.ConnectionId,
            new DateTime(2026, 7, 6), new DateTime(2026, 8, 5), 160,
            new DateTime(2026, 8, 6), new DateTime(2026, 8, 21), BillStatus.Paid, ratePerUnit);
        var bill3bUnpaid = Bill(customer3.CustomerId, conn1004.ConnectionId,
            new DateTime(2026, 8, 6), new DateTime(2026, 9, 5), 170,
            new DateTime(2026, 9, 6), new DateTime(2026, 10, 6), BillStatus.Unpaid, ratePerUnit);

        context.Bills.AddRange(bill1Paid, bill1Current, bill2Paid, bill2Partial, bill3aPaid, bill3aOverdue, bill3bPaid, bill3bUnpaid);
        await context.SaveChangesAsync();

        var payments = new List<Payment>
        {
            Payment(bill1Paid, customer1.CustomerId, bill1Paid.Amount, PaymentMethod.Card, PaymentSource.CustomerPortal, new DateTime(2026, 8, 20)),
            Payment(bill2Paid, customer2.CustomerId, bill2Paid.Amount, PaymentMethod.Cash, PaymentSource.AdminOffice, new DateTime(2026, 8, 15)),
            Payment(bill2Partial, customer2.CustomerId, 2000m, PaymentMethod.OnlineBanking, PaymentSource.CustomerPortal, new DateTime(2026, 9, 15)),
            Payment(bill3aPaid, customer3.CustomerId, bill3aPaid.Amount, PaymentMethod.BankTransfer, PaymentSource.ThirdPartyPartner, new DateTime(2026, 8, 10)),
            Payment(bill3bPaid, customer3.CustomerId, bill3bPaid.Amount, PaymentMethod.Cheque, PaymentSource.AdminOffice, new DateTime(2026, 8, 12)),
        };
        context.Payments.AddRange(payments);
        await context.SaveChangesAsync();

        var receipts = payments.Select(p => new PaymentReceipt
        {
            PaymentId = p.PaymentId,
            ReceiptNumber = $"RCPT-{p.PaymentId:D6}",
            IssuedDate = p.PaymentDate
        });
        context.PaymentReceipts.AddRange(receipts);

        context.ThirdPartyPartners.AddRange(
            new ThirdPartyPartner
            {
                PartnerName = "LankaPay Aggregator (Demo)",
                ApiKey = "demo-partner-key-12345",
                Status = PartnerStatus.Active
            },
            new ThirdPartyPartner
            {
                PartnerName = "Suspended Test Partner (Demo)",
                ApiKey = "demo-suspended-key-99999",
                Status = PartnerStatus.Suspended
            });

        context.NwsdbAdmins.Add(new NwsdbAdmin
        {
            FullName = "System Administrator",
            Username = "admin",
            PasswordHash = BCrypt.Net.BCrypt.HashPassword("Admin@123")
        });

        await context.SaveChangesAsync();
    }

    private static MeterReading Reading(int connectionId, DateTime date, decimal previous, decimal current) => new()
    {
        ConnectionId = connectionId,
        ReadingDate = date,
        PreviousReading = previous,
        CurrentReading = current,
        UnitsConsumed = current - previous
    };

    private static Bill Bill(
        int customerId, int connectionId,
        DateTime periodStart, DateTime periodEnd, decimal units,
        DateTime issuedDate, DateTime dueDate, BillStatus status, decimal ratePerUnit) => new()
    {
        CustomerId = customerId,
        ConnectionId = connectionId,
        BillingPeriodStart = periodStart,
        BillingPeriodEnd = periodEnd,
        UnitsConsumed = units,
        Amount = units * ratePerUnit,
        IssuedDate = issuedDate,
        DueDate = dueDate,
        Status = status
    };

    private static Payment Payment(
        Bill bill, int customerId, decimal amountPaid,
        PaymentMethod method, PaymentSource source, DateTime date) => new()
    {
        BillId = bill.BillId,
        CustomerId = customerId,
        AmountPaid = amountPaid,
        PaymentDate = date,
        PaymentMethod = method,
        Source = source,
        TransactionReference = $"TXN-{date:yyyyMMddHHmmss}-{Guid.NewGuid().ToString("N")[..6].ToUpperInvariant()}"
    };
}
