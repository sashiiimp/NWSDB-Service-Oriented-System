using NWSDB.Server.DTOs;

namespace NWSDB.Server.Services.Interfaces;

public interface IAdminService
{
    // Returns null when the username/password is wrong.
    Task<AdminLoginResponseDto?> LoginAsync(AdminLoginRequestDto request);

    Task<List<AdminCustomerDto>> GetCustomersAsync();
    Task<List<AdminConnectionDto>> GetConnectionsAsync();
    Task<MeterReadingDto> RecordMeterReadingAsync(CreateMeterReadingRequestDto request);
    Task<BillDto> GenerateBillAsync(GenerateBillRequestDto request);
}
