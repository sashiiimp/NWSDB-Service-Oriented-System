using NWSDB.Server.DTOs;

namespace NWSDB.Server.Services.Interfaces;

public interface IWaterUsageService
{
    Task<List<MeterReadingDto>> GetCurrentUsageAsync(int customerId);
    Task<List<MeterReadingDto>> GetUsageHistoryAsync(int customerId);
}
