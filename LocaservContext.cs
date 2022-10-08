using Microsoft.EntityFrameworkCore;

namespace Locaserv.Bdv.Api
{
    public class LocaservContext : DbContext, ILocaservContext
    {
        public LocaservContext(DbContextOptions<LocaservContext> options) : base(options)
        {
        }
    }
}