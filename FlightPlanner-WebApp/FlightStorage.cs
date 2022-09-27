using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;

namespace FlightPlanner_WebApp
{
    public class FlightStorage
    {
        private static List<Flight> _flights = new List<Flight>();
        public static readonly object LockObject = new object();

        private static int _id = 1;

        public static Flight AddFlight(Flight flight)
        {
            //lock (LockObject)
            //{
                flight.Id = _id++;
                _flights.Add(flight);
                return flight;
            //}
                
            
        }

        public static Flight GetFlight(int id)
        {
            //lock (LockObject)
            //{
                return _flights.FirstOrDefault(f => f.Id == id);
            //}
        }

        public static void Clear()
        {
            //lock (LockObject)
            //{
                _flights.Clear();
                _id = 0;
            //}
               
        }

        public static bool FlightExist(Flight flight)
        {

            //lock (LockObject)
            //{
                if (_flights.Count == 0)
                {
                    return false;
                }
                foreach (Flight storedFlight in _flights)
                {
                    if (storedFlight.Equals(flight))
                    {
                        return true;
                    }
                }
                return false;
            //}
        }

        public static void DeleteFlight(int id)
        {
            //lock (LockObject)
           // {
                var flight = GetFlight(id);
                if (flight != null)
                {
                    _flights.Remove(flight);
                }
            //}
           
        }

        public static HashSet<Airport> GetAllAirports()
        {
            //lock (LockObject)
            //{
                var airports = new HashSet<Airport>();

                foreach (Flight flight in _flights)
                {
                    airports.Add(flight.From);
                    airports.Add(flight.To);
                }

                return airports;
            //}
            
        }

        public static Airport FindAirport(Airport airport)
        {
            //lock (LockObject)
            //{
                var airports = GetAllAirports();

                foreach (Airport tempAirport in airports)
                {
                    if (tempAirport.Equals(airport))
                    {
                        return tempAirport;
                    }
                }

                return null;
            //}
            
        }

        public static List<Airport> FindAirportByParameter(string search) 
        {
            var matchedAirports = new List<Airport>();
            var airports = GetAllAirports();

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
                var departureTMTEST = Convert.ToDateTime(flight.DepartureTime).ToString("yyyy-MM-dd");
                var reqstTMTEST = request.DepartureTime;
                var departureTime = Convert.ToDateTime(flight.DepartureTime).ToString("yyyy-MM-dd") == request.DepartureTime;
                if (airportNameEq && airpoertNameEqTo && departureTime)


                {
                    flightResults.Add(flight.From.AirportName);
                }
            }
            return new SearchFlightResult(flightResults, 0, flightResults.Count);
        } 
    }
}

