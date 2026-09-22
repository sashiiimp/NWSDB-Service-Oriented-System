using Microsoft.EntityFrameworkCore;
using NWSDB.Server.Data;
using NWSDB.Server.Middleware;
using NWSDB.Server.Services;
using NWSDB.Server.Services.Interfaces;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(options =>
{
    options.SwaggerDoc("v1", new Microsoft.OpenApi.Models.OpenApiInfo
    {
        Title = "NWSDB Service-Oriented Water Billing and Payment System API",
        Version = "v1",
        Description = "Student prototype API (CSE5013 Service Oriented Computing) modelled on an NWSDB case study. " +
                      "Not affiliated with, and not the production system of, the real National Water Supply and Drainage Board."
    });

    options.AddSecurityDefinition("ApiKey", new Microsoft.OpenApi.Models.OpenApiSecurityScheme
    {
        Name = "X-Api-Key",
        Type = Microsoft.OpenApi.Models.SecuritySchemeType.ApiKey,
        In = Microsoft.OpenApi.Models.ParameterLocation.Header,
        Description = "Required for /api/partner/** endpoints. Demo key seeded in the database: demo-partner-key-12345"
    });
});

// Database provider is selected from configuration so the same EF Core model
// can target SQL Server (the eventual Visual Studio / production target) or
// SQLite (zero-setup local dev, used here in the SSH environment) without any
// code changes - see appsettings.json -> Database:Provider.
var dbProvider = builder.Configuration["Database:Provider"] ?? "Sqlite";

builder.Services.AddDbContext<NwsdbDbContext>(options =>
{
    if (string.Equals(dbProvider, "SqlServer", StringComparison.OrdinalIgnoreCase))
    {
        options.UseSqlServer(builder.Configuration.GetConnectionString("SqlServerConnection"));
    }
    else
    {
        options.UseSqlite(builder.Configuration.GetConnectionString("SqliteConnection"));
    }
});

// Service-oriented layer: controllers depend on these interfaces, never on
// NwsdbDbContext directly.
builder.Services.AddScoped<ICustomerService, CustomerService>();
builder.Services.AddScoped<IWaterUsageService, WaterUsageService>();
builder.Services.AddScoped<IBillingService, BillingService>();
builder.Services.AddScoped<IPaymentService, PaymentService>();

var app = builder.Build();

// Ensure the database schema exists and seed demo data. EnsureCreated() is
// used instead of Migrate() because the provider can change between SQLite
// (here) and SQL Server (Visual Studio) - see README section on database
// setup for how to switch to proper EF Core migrations once the target
// provider is fixed to SQL Server.
using (var scope = app.Services.CreateScope())
{
    var db = scope.ServiceProvider.GetRequiredService<NwsdbDbContext>();
    db.Database.EnsureCreated();
    await SeedData.SeedAsync(db);
}

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseMiddleware<ExceptionHandlingMiddleware>();

app.UseHttpsRedirection();

// API-key auth applies only to partner-facing routes.
app.UseWhen(
    context => context.Request.Path.StartsWithSegments("/api/partner"),
    appBuilder => appBuilder.UseMiddleware<ApiKeyAuthMiddleware>());

app.UseAuthorization();

app.MapControllers();

app.Run();
