using System.Text.Json.Serialization;

namespace FlightPlanner.Core.Models
{
    public class SearchFlightRequest
    {
        public string From { get; set; }
        public string To { get; set; }
        [JsonPropertyName("departureDate")]
        public string DepartureTime { get; set; }
    }
}
