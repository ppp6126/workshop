using Microsoft.EntityFrameworkCore;
using WebApplication1.th.co.Model;

namespace WebApplication1.th.co.utils;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

    public DbSet<Region> Regions => Set<Region>();
    public DbSet<DisasterType> DisasterTypes => Set<DisasterType>();
    public DbSet<RegionDisasterType> RegionDisasterTypes => Set<RegionDisasterType>();
    public DbSet<AlertSetting> AlertSettings => Set<AlertSetting>();
    public DbSet<DisasterRisk> DisasterRisks => Set<DisasterRisk>();
    public DbSet<Alert> Alerts => Set<Alert>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<RegionDisasterType>()
            .HasKey(rd => new { rd.RegionId, rd.DisasterTypeId });

        modelBuilder.Entity<RegionDisasterType>()
            .HasOne(rd => rd.Region)
            .WithMany(r => r.DisasterTypes)
            .HasForeignKey(rd => rd.RegionId);

        modelBuilder.Entity<RegionDisasterType>()
            .HasOne(rd => rd.DisasterType)
            .WithMany(d => d.Regions)
            .HasForeignKey(rd => rd.DisasterTypeId);
    }
}