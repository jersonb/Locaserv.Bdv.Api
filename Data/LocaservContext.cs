using Locaserv.Bdv.Api.Models;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace Locaserv.Bdv.Api.Data;

public class LocaservContext : DbContext, ILocaservContext
{
    public LocaservContext(DbContextOptions<LocaservContext> options) : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.HasDefaultSchema("bdv");
        base.OnModelCreating(modelBuilder);
    }

    public DbSet<Vehicle> Vehicles { get; set; }

    public DbSet<Conductor> Conductors { get; set; }

    public DbSet<ConductorVehicle> ConductorsVehicles { get; set; }

    public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        => await base.SaveChangesAsync(cancellationToken);
}