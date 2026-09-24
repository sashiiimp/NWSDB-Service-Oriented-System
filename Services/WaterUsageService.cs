using Microsoft.EntityFrameworkCore;
using NWSDB.Server.Data;
using NWSDB.Server.DTOs;
using NWSDB.Server.Services.Exceptions;
using NWSDB.Server.Services.Interfaces;

namespace NWSDB.Server.Services;

public class WaterUsageService : IWaterUsageService
{
    private readonly NwsdbDbContext _db;

    public WaterUsageService(NwsdbDbContext db)
    {
        _db = db;
    }

    // "Current" usage = the most recent meter reading for each of the customer's connections.
    public async Task<List<MeterReadingDto>> GetCurrentUsageAsync(int customerId)
    {
        await EnsureCustomerExists(customerId);

        var connectionIds = await _db.WaterConnections
            .Where(wc => wc.CustomerId == customerId)
            .Select(wc => wc.ConnectionId)
            .ToListAsync();

        var latestReadings = new List<MeterReadingDto>();
        foreach (var connectionId in connectionIds)
        {
            var latest = await _db.MeterReadings
                .AsNoTracking()
                .Where(mr => mr.ConnectionId == connectionId)
                .OrderByDescending(mr => mr.ReadingDate)
                .FirstOrDefaultAsync();

            if (latest is not null)
            {
                latestReadings.Add(ToDto(latest));
            }
        }

        return latestReadings;
    }

    public async Task<List<MeterReadingDto>> GetUsageHistoryAsync(int customerId)
    {
        await EnsureCustomerExists(customerId);

        return await _db.MeterReadings
            .AsNoTracking()
            .Where(mr => mr.Connection!.CustomerId == customerId)
            .OrderByDescending(mr => mr.ReadingDate)
            .Select(mr => new MeterReadingDto
            {
                ReadingId = mr.ReadingId,
                ConnectionId = mr.ConnectionId,
                ReadingDate = mr.ReadingDate,
                PreviousReading = mr.PreviousReading,
                CurrentReading = mr.CurrentReading,
                UnitsConsumed = mr.UnitsConsumed
            })
            .ToListAsync();
    }

    private async Task EnsureCustomerExists(int customerId)
    {
        var exists = await _db.Customers.AnyAsync(c => c.CustomerId == customerId);
        if (!exists)
        {
            throw new NotFoundException($"Customer {customerId} was not found.");
        }
    }

    internal static MeterReadingDto ToDto(Models.MeterReading mr) => new()
    {
        ReadingId = mr.ReadingId,
        ConnectionId = mr.ConnectionId,
        ReadingDate = mr.ReadingDate,
        PreviousReading = mr.PreviousReading,
        CurrentReading = mr.CurrentReading,
        UnitsConsumed = mr.UnitsConsumed
    };
}
