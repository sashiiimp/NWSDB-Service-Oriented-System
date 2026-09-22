using NWSDB.Server.DTOs;
using NWSDB.Server.Models;

namespace NWSDB.Server.Services.Interfaces;

public interface IPaymentService
{
    Task<PaymentDto> CreatePaymentAsync(CreatePaymentRequestDto request, PaymentSource source);
    Task<List<PaymentDto>> GetPaymentHistoryAsync(int customerId);
    Task<PaymentReceiptDto> GetReceiptAsync(int paymentId);
}
