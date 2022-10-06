using Microsoft.EntityFrameworkCore;

namespace FlightPlanner_WebApp.Data
{
    public class FlightPlannerDbContext : DbContext
    {
        public FlightPlannerDbContext(DbContextOptions<FlightPlannerDbContext> options) : base(options)
        {
        }

        public DbSet<Flight> Flights { get; set; }

        public DbSet<Airport> Airports { get; set; }
    }
}
