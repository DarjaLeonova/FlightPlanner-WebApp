using FlightPlanner_WebApp.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace FlightPlanner_WebApp
{
    public class FlightStorage
    {
        private static int _id = 1;
        private readonly FlightPlannerDbContext _db;
        private static List<Flight> _flights;

        public FlightStorage(FlightPlannerDbContext db)
        {
            _db = db;
            _flights = _db.Flights
                .Include(x => x.From)
                .Include(x => x.To)
                .ToList();
        }

        public Flight AddFlight(Flight flight)
        {
            _db.Flights.Add(flight);
            _db.SaveChanges();

            return flight;
        }

        public Flight GetFlight(int id)
        {
            var flight = _db.Flights.Where(a => a.Id == id).Include(x => x.From).Include(x => x.To).FirstOrDefault();
            return flight;
        }

        public void Clear()
        {
            _id = 0;

            _db.Flights.RemoveRange(_db.Flights);
            _db.Airports.RemoveRange(_db.Airports);
            _db.SaveChanges();
        }

        public bool FlightExist(Flight flight)
        {
            _flights = _db.Flights
                .Include(x => x.From)
                .Include(x => x.To)
                .ToList();

            if (_db.Flights.Count() == 0)
            {
                return false;
            }

            foreach (var storedFlight in _flights)
            {
                var test = storedFlight;
                if (storedFlight.Equals(flight))
                {
                    return true;
                }
            }
            return false;
        }

        public Flight DeleteFlight(int id)
        {
            var flight = GetFlight(id);

            if (flight != null)
            {
                _db.Flights.Remove(flight);
                _db.SaveChanges();
                return flight;
            }
            return null;
        }

        public HashSet<Airport> GetAllAirports()
        {
            var airports = new HashSet<Airport>();

            foreach (Flight flight in _flights)
            {
                airports.Add(flight.From);
                airports.Add(flight.To);
            }
            return airports;
        }

        public List<Airport> FindAirportByParameter(string search)
        {
            var matchedAirports = new List<Airport>();
            var airports = _db.Airports.ToList();

            foreach (Airport airport in airports)
            {
                var cityEq = airport.City.Trim().ToUpper().StartsWith(search.Trim().ToUpper());
                var countryEq = airport.Country.Trim().ToUpper().StartsWith(search.Trim().ToUpper());
                var airportNameEq = airport.AirportName.Trim().StartsWith(search.Trim().ToUpper());

                if (cityEq || countryEq || airportNameEq)
                {
                    matchedAirports.Add(airport);
                }
            }
            return matchedAirports;
        }

        public static SearchFlightResult GetMatchedFlightResult(SearchFlightsRequest request)
        {
            List<string> flightResults = new List<string>();

            foreach (Flight flight in _flights)
            {
                var airportNameEq = flight.From.AirportName == request.From;
                var airpoertNameEqTo = flight.To.AirportName == request.To;
                var departureTime = Convert.ToDateTime(flight.DepartureTime).ToString("yyyy-MM-dd");
                var reqstTime = request.DepartureTime;
                var departTime = departureTime == reqstTime;

                if (airportNameEq && airpoertNameEqTo && departTime)
                {
                    flightResults.Add(flight.From.AirportName);
                }
            }
            return new SearchFlightResult(flightResults, 0, flightResults.Count);
        }
    }
}

