using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using NWSDB.Server.Data;
using NWSDB.Server.DTOs;
using NWSDB.Server.Models;
using NWSDB.Server.Services.Exceptions;
using NWSDB.Server.Services.Interfaces;

namespace NWSDB.Server.Services;

// Operations performed by the NWSDB Admin actor: signing in, looking up
// customers/connections, recording meter readings and generating bills.
public class AdminService : IAdminService
{
    public const string AdminRole = "Admin";

    // Flat tariff and payment terms - the same values used for the seeded bills.
    private const decimal RatePerUnit = 100m;
    private const int PaymentDueDays = 15;

    private readonly NwsdbDbContext _db;
    private readonly JwtSettings _jwtSettings;

    public AdminService(NwsdbDbContext db, IOptions<JwtSettings> jwtSettings)
    {
        _db = db;
        _jwtSettings = jwtSettings.Value;
    }

    public async Task<AdminLoginResponseDto?> LoginAsync(AdminLoginRequestDto request)
    {
        var admin = await _db.NwsdbAdmins.AsNoTracking()
            .FirstOrDefaultAsync(a => a.Username == request.Username);

        if (admin is null || !BCrypt.Net.BCrypt.Verify(request.Password, admin.PasswordHash))
        {
            return null;
        }

        var expiresAt = DateTime.UtcNow.AddMinutes(_jwtSettings.ExpiryMinutes);
        return new AdminLoginResponseDto
        {
            AdminId = admin.AdminId,
            Username = admin.Username,
            FullName = admin.FullName,
            Token = CreateToken(admin, expiresAt),
            ExpiresAtUtc = expiresAt
        };
    }

    public async Task<List<AdminCustomerDto>> GetCustomersAsync()
    {
        return await _db.Customers
            .AsNoTracking()
            .OrderBy(c => c.AccountNumber)
            .Select(c => new AdminCustomerDto
            {
                CustomerId = c.CustomerId,
                AccountNumber = c.AccountNumber,
                FullName = c.FullName,
                Email = c.Email,
                Phone = c.Phone,
                Address = c.Address,
                Connections = c.WaterConnections
                    .OrderBy(wc => wc.ConnectionNumber)
                    .Select(wc => new WaterConnectionDto
                    {
                        ConnectionId = wc.ConnectionId,
                        CustomerId = wc.CustomerId,
                        ConnectionNumber = wc.ConnectionNumber,
                        ConnectionAddress = wc.ConnectionAddress,
                        Status = wc.Status.ToString()
                    })
                    .ToList()
            })
            .ToListAsync();
    }

    public async Task<List<AdminConnectionDto>> GetConnectionsAsync()
    {
        var connections = await _db.WaterConnections
            .AsNoTracking()
            .Include(wc => wc.Customer)
            .OrderBy(wc => wc.ConnectionNumber)
            .ToListAsync();

        var result = new List<AdminConnectionDto>();
        foreach (var wc in connections)
        {
            var latest = await GetLatestReadingAsync(wc.ConnectionId);
            result.Add(new AdminConnectionDto
            {
                ConnectionId = wc.ConnectionId,
                ConnectionNumber = wc.ConnectionNumber,
                ConnectionAddress = wc.ConnectionAddress,
                Status = wc.Status.ToString(),
                CustomerId = wc.CustomerId,
                AccountNumber = wc.Customer!.AccountNumber,
                CustomerName = wc.Customer.FullName,
                LatestReadingId = latest?.ReadingId,
                LatestReadingDate = latest?.ReadingDate,
                LatestReadingValue = latest?.CurrentReading
            });
        }

        return result;
    }

    public async Task<MeterReadingDto> RecordMeterReadingAsync(CreateMeterReadingRequestDto request)
    {
        var connection = await _db.WaterConnections.AsNoTracking()
            .FirstOrDefaultAsync(wc => wc.ConnectionId == request.ConnectionId)
            ?? throw new NotFoundException($"Water connection {request.ConnectionId} was not found.");

        if (connection.Status != ConnectionStatus.Active)
        {
            throw new BusinessValidationException(
                $"Readings cannot be recorded for connection {connection.ConnectionNumber} because it is {connection.Status}.");
        }

        var readingDate = request.ReadingDate.Date;
        if (readingDate == default)
        {
            throw new BusinessValidationException("ReadingDate is required.");
        }

        if (readingDate > DateTime.UtcNow.Date)
        {
            throw new BusinessValidationException("ReadingDate cannot be in the future.");
        }

        var latest = await GetLatestReadingAsync(connection.ConnectionId);
        decimal previousReading;

        if (latest is null)
        {
            previousReading = request.PreviousReading ?? 0m;
        }
        else
        {
            if (readingDate == latest.ReadingDate.Date)
            {
                throw new ConflictException(
                    $"A reading for connection {connection.ConnectionNumber} has already been recorded on {readingDate:yyyy-MM-dd}.");
            }

            if (readingDate < latest.ReadingDate.Date)
            {
                throw new BusinessValidationException(
                    $"ReadingDate must be after the latest reading date ({latest.ReadingDate:yyyy-MM-dd}) for connection {connection.ConnectionNumber}.");
            }

            previousReading = latest.CurrentReading;

            if (request.PreviousReading.HasValue && request.PreviousReading.Value != previousReading)
            {
                throw new BusinessValidationException(
                    $"PreviousReading must be {previousReading:F2} (the latest recorded reading for connection {connection.ConnectionNumber}). " +
                    "Omit PreviousReading to use it automatically.");
            }
        }

        if (request.CurrentReading < previousReading)
        {
            throw new BusinessValidationException(
                $"CurrentReading ({request.CurrentReading:F2}) cannot be lower than PreviousReading ({previousReading:F2}).");
        }

        var reading = new MeterReading
        {
            ConnectionId = connection.ConnectionId,
            ReadingDate = readingDate,
            PreviousReading = previousReading,
            CurrentReading = request.CurrentReading,
            UnitsConsumed = request.CurrentReading - previousReading
        };

        _db.MeterReadings.Add(reading);
        await _db.SaveChangesAsync();

        return WaterUsageService.ToDto(reading);
    }

    // Bills cover the period from the day after the previous reading up to this
    // reading, matching the seeded bills (e.g. reading on 15 Aug -> 16 Jul to 15 Aug).
    public async Task<BillDto> GenerateBillAsync(GenerateBillRequestDto request)
    {
        var reading = await _db.MeterReadings.AsNoTracking()
            .Include(mr => mr.Connection)
            .FirstOrDefaultAsync(mr => mr.ReadingId == request.ReadingId)
            ?? throw new NotFoundException($"Meter reading {request.ReadingId} was not found.");

        if (reading.UnitsConsumed <= 0)
        {
            throw new BusinessValidationException(
                $"Meter reading {reading.ReadingId} has no consumption ({reading.UnitsConsumed:F2} units), so no bill can be generated.");
        }

        var previousReadingDate = await _db.MeterReadings.AsNoTracking()
            .Where(mr => mr.ConnectionId == reading.ConnectionId && mr.ReadingDate < reading.ReadingDate)
            .OrderByDescending(mr => mr.ReadingDate)
            .Select(mr => (DateTime?)mr.ReadingDate)
            .FirstOrDefaultAsync();

        var periodEnd = reading.ReadingDate.Date;
        var periodStart = previousReadingDate?.Date.AddDays(1) ?? periodEnd.AddMonths(-1).AddDays(1);

        // Duplicate/overlap guard: a connection can only be billed once for any given day.
        var overlappingBill = await _db.Bills.AsNoTracking()
            .Where(b => b.ConnectionId == reading.ConnectionId
                        && b.BillingPeriodStart <= periodEnd
                        && b.BillingPeriodEnd >= periodStart)
            .Select(b => new { b.BillId, b.BillingPeriodStart, b.BillingPeriodEnd })
            .FirstOrDefaultAsync();

        if (overlappingBill is not null)
        {
            throw new ConflictException(
                $"Connection {reading.Connection!.ConnectionNumber} has already been billed for this period " +
                $"(bill {overlappingBill.BillId}: {overlappingBill.BillingPeriodStart:yyyy-MM-dd} to {overlappingBill.BillingPeriodEnd:yyyy-MM-dd}).");
        }

        var issuedDate = DateTime.UtcNow.Date;
        var bill = new Bill
        {
            CustomerId = reading.Connection!.CustomerId,
            ConnectionId = reading.ConnectionId,
            BillingPeriodStart = periodStart,
            BillingPeriodEnd = periodEnd,
            UnitsConsumed = reading.UnitsConsumed,
            Amount = reading.UnitsConsumed * RatePerUnit,
            IssuedDate = issuedDate,
            DueDate = issuedDate.AddDays(PaymentDueDays),
            Status = BillStatus.Unpaid
        };

        _db.Bills.Add(bill);
        await _db.SaveChangesAsync();

        return BillingService.ToDto(bill);
    }

    private Task<MeterReading?> GetLatestReadingAsync(int connectionId) =>
        _db.MeterReadings.AsNoTracking()
            .Where(mr => mr.ConnectionId == connectionId)
            .OrderByDescending(mr => mr.ReadingDate)
            .FirstOrDefaultAsync();

    private string CreateToken(NwsdbAdmin admin, DateTime expiresAt)
    {
        var claims = new[]
        {
            new Claim(JwtRegisteredClaimNames.Sub, admin.AdminId.ToString()),
            new Claim(ClaimTypes.Name, admin.Username),
            new Claim(ClaimTypes.Role, AdminRole)
        };

        var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_jwtSettings.SigningKey));
        var token = new JwtSecurityToken(
            issuer: _jwtSettings.Issuer,
            audience: _jwtSettings.Audience,
            claims: claims,
            expires: expiresAt,
            signingCredentials: new SigningCredentials(key, SecurityAlgorithms.HmacSha256));

        return new JwtSecurityTokenHandler().WriteToken(token);
    }
}
