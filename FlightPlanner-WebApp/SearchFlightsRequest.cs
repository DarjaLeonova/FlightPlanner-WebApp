using System;
using System.Text.Json.Serialization;

namespace FlightPlanner_WebApp
{
    public class SearchFlightsRequest
    {
        public string From { get; set; }
        public string To { get; set; }
        [JsonPropertyName("departureDate")]
        public string DepartureTime { get; set; }
        public static readonly object LockObject = new object();

        public bool ObjectValidation()
        {
            if (From == null || To == null) return true;

            var checkFrom = string.IsNullOrEmpty(From);
            var checkTo = string.IsNullOrEmpty(To);
            var checkDeparture = string.IsNullOrEmpty(DepartureTime);

            return checkFrom ||
                checkTo ||
                checkDeparture;  
        }

        public bool AirportValidation()
        {
            if (From == To) return true;
            return false;
        }
    }
}