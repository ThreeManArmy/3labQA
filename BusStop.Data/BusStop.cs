using BusStop.Data.BusStop;
using BusStop.Data.Client;
using Microsoft.EntityFrameworkCore;
namespace BusStop.Data
{
    public class BusStopContext : DbContext
    {
        public DbSet<BusDto> BusStations { get; set; }
        public DbSet<ClientDto> Clients { get; set; }

        public BusStopContext(DbContextOptions<BusStopContext> options) : base(options)
        {
            
        }
    }
}