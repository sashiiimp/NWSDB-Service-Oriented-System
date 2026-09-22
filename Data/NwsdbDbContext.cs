using Microsoft.EntityFrameworkCore;
using NWSDB.Server.Models;

namespace NWSDB.Server.Data;

public class NwsdbDbContext : DbContext
{
    public NwsdbDbContext(DbContextOptions<NwsdbDbContext> options) : base(options)
    {
    }

    public DbSet<Customer> Customers => Set<Customer>();
    public DbSet<WaterConnection> WaterConnections => Set<WaterConnection>();
    public DbSet<MeterReading> MeterReadings => Set<MeterReading>();
    public DbSet<Bill> Bills => Set<Bill>();
    public DbSet<Payment> Payments => Set<Payment>();
    public DbSet<PaymentReceipt> PaymentReceipts => Set<PaymentReceipt>();
    public DbSet<NwsdbAdmin> NwsdbAdmins => Set<NwsdbAdmin>();
    public DbSet<ThirdPartyPartner> ThirdPartyPartners => Set<ThirdPartyPartner>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        // Explicit primary keys: several id properties (e.g. WaterConnection.ConnectionId)
        // don't match EF Core's default "<TypeName>Id" / "Id" key convention, so they
        // must be declared here rather than relying on convention.
        modelBuilder.Entity<Customer>().HasKey(e => e.CustomerId);
        modelBuilder.Entity<WaterConnection>().HasKey(e => e.ConnectionId);
        modelBuilder.Entity<MeterReading>().HasKey(e => e.ReadingId);
        modelBuilder.Entity<Bill>().HasKey(e => e.BillId);
        modelBuilder.Entity<Payment>().HasKey(e => e.PaymentId);
        modelBuilder.Entity<PaymentReceipt>().HasKey(e => e.ReceiptId);
        modelBuilder.Entity<NwsdbAdmin>().HasKey(e => e.AdminId);
        modelBuilder.Entity<ThirdPartyPartner>().HasKey(e => e.PartnerId);

        // Store enums as readable strings (nicer in Swagger/DB screenshots than raw ints).
        modelBuilder.Entity<WaterConnection>().Property(e => e.Status).HasConversion<string>().HasMaxLength(20);
        modelBuilder.Entity<Bill>().Property(e => e.Status).HasConversion<string>().HasMaxLength(20);
        modelBuilder.Entity<Payment>().Property(e => e.PaymentMethod).HasConversion<string>().HasMaxLength(20);
        modelBuilder.Entity<Payment>().Property(e => e.Source).HasConversion<string>().HasMaxLength(20);
        modelBuilder.Entity<ThirdPartyPartner>().Property(e => e.Status).HasConversion<string>().HasMaxLength(20);

        // Decimal precision, explicit for SQL Server compatibility.
        modelBuilder.Entity<MeterReading>().Property(e => e.PreviousReading).HasColumnType("decimal(18,2)");
        modelBuilder.Entity<MeterReading>().Property(e => e.CurrentReading).HasColumnType("decimal(18,2)");
        modelBuilder.Entity<MeterReading>().Property(e => e.UnitsConsumed).HasColumnType("decimal(18,2)");
        modelBuilder.Entity<Bill>().Property(e => e.UnitsConsumed).HasColumnType("decimal(18,2)");
        modelBuilder.Entity<Bill>().Property(e => e.Amount).HasColumnType("decimal(18,2)");
        modelBuilder.Entity<Payment>().Property(e => e.AmountPaid).HasColumnType("decimal(18,2)");

        modelBuilder.Entity<Customer>()
            .HasIndex(c => c.AccountNumber)
            .IsUnique();

        modelBuilder.Entity<WaterConnection>()
            .HasIndex(c => c.ConnectionNumber)
            .IsUnique();

        modelBuilder.Entity<ThirdPartyPartner>()
            .HasIndex(p => p.ApiKey)
            .IsUnique();

        modelBuilder.Entity<NwsdbAdmin>()
            .HasIndex(a => a.Username)
            .IsUnique();

        // Customer -> WaterConnections
        modelBuilder.Entity<WaterConnection>()
            .HasOne(wc => wc.Customer)
            .WithMany(c => c.WaterConnections)
            .HasForeignKey(wc => wc.CustomerId)
            .OnDelete(DeleteBehavior.Cascade);

        // WaterConnection -> MeterReadings
        modelBuilder.Entity<MeterReading>()
            .HasOne(mr => mr.Connection)
            .WithMany(wc => wc.MeterReadings)
            .HasForeignKey(mr => mr.ConnectionId)
            .OnDelete(DeleteBehavior.Cascade);

        // Customer -> Bills, WaterConnection -> Bills
        modelBuilder.Entity<Bill>()
            .HasOne(b => b.Customer)
            .WithMany(c => c.Bills)
            .HasForeignKey(b => b.CustomerId)
            .OnDelete(DeleteBehavior.Restrict);

        modelBuilder.Entity<Bill>()
            .HasOne(b => b.Connection)
            .WithMany(wc => wc.Bills)
            .HasForeignKey(b => b.ConnectionId)
            .OnDelete(DeleteBehavior.Restrict);

        // Bill -> Payments, Customer -> Payments
        modelBuilder.Entity<Payment>()
            .HasOne(p => p.Bill)
            .WithMany(b => b.Payments)
            .HasForeignKey(p => p.BillId)
            .OnDelete(DeleteBehavior.Restrict);

        modelBuilder.Entity<Payment>()
            .HasOne(p => p.Customer)
            .WithMany(c => c.Payments)
            .HasForeignKey(p => p.CustomerId)
            .OnDelete(DeleteBehavior.Restrict);

        // Payment -> PaymentReceipt (1:1)
        modelBuilder.Entity<PaymentReceipt>()
            .HasOne(r => r.Payment)
            .WithOne(p => p.Receipt)
            .HasForeignKey<PaymentReceipt>(r => r.PaymentId)
            .OnDelete(DeleteBehavior.Cascade);

        modelBuilder.Entity<PaymentReceipt>()
            .HasIndex(r => r.ReceiptNumber)
            .IsUnique();
    }
}
