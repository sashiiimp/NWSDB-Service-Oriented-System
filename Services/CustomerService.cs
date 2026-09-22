using Microsoft.EntityFrameworkCore;
using NWSDB.Server.Data;
using NWSDB.Server.DTOs;
using NWSDB.Server.Services.Exceptions;
using NWSDB.Server.Services.Interfaces;

namespace NWSDB.Server.Services;

public class CustomerService : ICustomerService
{
    private readonly NwsdbDbContext _db;

    public CustomerService(NwsdbDbContext db)
    {
        _db = db;
    }

    public async Task<CustomerDto> GetByIdAsync(int customerId)
    {
        var customer = await _db.Customers.AsNoTracking().FirstOrDefaultAsync(c => c.CustomerId == customerId)
            ?? throw new NotFoundException($"Customer {customerId} was not found.");

        return ToDto(customer);
    }

    public async Task<CustomerDto> GetByAccountNumberAsync(string accountNumber)
    {
        var customer = await _db.Customers.AsNoTracking()
            .FirstOrDefaultAsync(c => c.AccountNumber == accountNumber)
            ?? throw new NotFoundException($"Customer with account number '{accountNumber}' was not found.");

        return ToDto(customer);
    }

    public async Task<List<WaterConnectionDto>> GetConnectionsForCustomerAsync(int customerId)
    {
        var exists = await _db.Customers.AnyAsync(c => c.CustomerId == customerId);
        if (!exists)
        {
            throw new NotFoundException($"Customer {customerId} was not found.");
        }

        return await _db.WaterConnections
            .AsNoTracking()
            .Where(wc => wc.CustomerId == customerId)
            .Select(wc => new WaterConnectionDto
            {
                ConnectionId = wc.ConnectionId,
                CustomerId = wc.CustomerId,
                ConnectionNumber = wc.ConnectionNumber,
                ConnectionAddress = wc.ConnectionAddress,
                Status = wc.Status.ToString()
            })
            .ToListAsync();
    }

    private static CustomerDto ToDto(Models.Customer c) => new()
    {
        CustomerId = c.CustomerId,
        AccountNumber = c.AccountNumber,
        FullName = c.FullName,
        Email = c.Email,
        Phone = c.Phone,
        Address = c.Address
    };
}
