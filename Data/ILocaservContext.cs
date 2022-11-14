using Locaserv.Bdv.Api.Models;
using Microsoft.EntityFrameworkCore;

namespace Locaserv.Bdv.Api.Data
{
    public interface ILocaservContext
    {
        DbSet<Vehicle> Vehicles { get; }
        DbSet<Conductor> Conductors { get; }
        DbSet<ConductorVehicle> ConductorsVehicles { get; }

        Task<int> SaveChangesAsync(CancellationToken cancellation = default);
    }
}