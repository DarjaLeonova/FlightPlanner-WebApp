using FlightPlanner.Core.Models;
using FlightPlanner.Core.Services;
using FlightPlanner_WebApp;
using FlightPlanner_WebApp.Data;
using Microsoft.EntityFrameworkCore;

namespace FlightPlanner.Services
{
    public class FlightService : EntityService<Flight>, IFlightService
    {
        public FlightService(FlightPlannerDbContext context) : base(context)
        {
        }

        public Flight GetCompleteFlightById(int id)
        {
            return _context.Flights
                .Include(f => f.From)
                .Include(f => f.To)
                .SingleOrDefault(f => f.Id == id);  
        }

        public bool Exists(Flight flight)
        {
            return _context.Flights.Any(f =>
                f.ArrivalTime == flight.ArrivalTime &&
                f.DepartureTime == flight.DepartureTime &&
                f.Carrier == flight.Carrier &&
                f.From.AirportName == flight.From.AirportName &&
                f.To.AirportName == flight.To.AirportName);
        }

        public List<Airport> SearchAirports(string word)
        {
            var result = _context.Airports.Where(a => a.AirportName.ToLower().Trim().Contains(word) || 
            a.Country.ToLower().Trim().Contains(word) || 
            a.City.ToLower().Trim().Contains(word)).ToList();

            return result.DistinctBy(a => a.AirportName).ToList();

        }

        public SearchFlightResult SearchFlightsByRequest(string from, string to, string departure)
        {
            var foundFlights = new List<Flight>();
            
            var flights = _context.Flights
                .Include(x => x.From)
                .Include(x => x.To).ToList();

            foreach (var item in flights)
            {
                var itemDate = DateTime.Parse(item.DepartureTime).ToString("yyyy-MM-dd");
                var targetDate = DateTime.Parse(departure).ToString("yyyy-MM-dd");

                if (itemDate == targetDate)
                {
                    foundFlights.Add(item);
                }
            }

            var result = new SearchFlightResult()
            {
                Items = foundFlights,
                Page = 0,
                TotalItems = foundFlights.Count()
            };

            return result;
        }

        public void DeleteAll()
        {
            _context.Flights.RemoveRange(_context.Flights);
            _context.Airports.RemoveRange(_context.Airports);
            _context.SaveChanges();
        }
    }
}
