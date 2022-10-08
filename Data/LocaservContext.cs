using Locaserv.Bdv.Api.Data;
using Locaserv.Bdv.Api.Models;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace Locaserv.Bdv.Api
{
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

        public DbSet<Test> Tests { get; set; }
    }
}