using NWSDB.Server.DTOs;

namespace NWSDB.Server.Services.Interfaces;

public interface IBillingService
{
    Task<BillDto> GetCurrentBillAsync(int customerId);
    Task<List<BillDto>> GetBillHistoryAsync(int customerId);
    Task<BillDto> GetBillDetailsAsync(int billId);
}
