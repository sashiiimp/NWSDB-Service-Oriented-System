using NWSDB.Server.DTOs;

namespace NWSDB.Server.Services.Interfaces;

public interface ICustomerService
{
    Task<CustomerDto> GetByIdAsync(int customerId);
    Task<CustomerDto> GetByAccountNumberAsync(string accountNumber);
    Task<List<WaterConnectionDto>> GetConnectionsForCustomerAsync(int customerId);
}
