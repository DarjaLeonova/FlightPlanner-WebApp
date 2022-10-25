using FlightPlanner.Core.Services;
using FlightPlanner_WebApp;
using FlightPlanner_WebApp.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlightPlanner.Services
{
    public class AirportService : EntityService<Airport>, IAirportService
    {
        public AirportService(FlightPlannerDbContext context) : base(context)
        {
        }
        public List<Airport> SearchAirports(string word)
        {
            var result = _context.Airports.Where(a => a.AirportName.ToLower().Trim().Contains(word) ||
            a.Country.ToLower().Trim().Contains(word) ||
            a.City.ToLower().Trim().Contains(word)).ToList();

            return result.DistinctBy(a => a.AirportName).ToList();

        }
    }
}
