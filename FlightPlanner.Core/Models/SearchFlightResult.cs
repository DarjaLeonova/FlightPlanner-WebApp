using FlightPlanner_WebApp;

namespace FlightPlanner.Core.Models
{
    public class SearchFlightResult
    {
        public List<Flight>? Items { get; set; }
        public int Page { get; set; }
        public int TotalItems { get; set; }
    }
}
