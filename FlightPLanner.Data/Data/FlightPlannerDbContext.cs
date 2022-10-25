using FlightPLanner.Data.Data;
using Microsoft.EntityFrameworkCore;

namespace FlightPlanner_WebApp.Data
{
    public class FlightPlannerDbContext : DbContext, IFlightPlannerDbContext
    {
        public DbSet<Flight> Flights { get; set; }
        public DbSet<Airport> Airports { get; set; }

        public FlightPlannerDbContext(DbContextOptions<FlightPlannerDbContext> options) : base(options)
        {
        }

        public Task<int> SaveChangesAsync()
        {
            return base.SaveChangesAsync();
        }
    }
}
