using FlightPlanner.Core.Models;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace FlightPlanner_WebApp
{
    public class Airport : Entity
    {
    
        public string Country { get; set; }
        public string City { get; set; }
        [JsonPropertyName("airport")]
        public string AirportName { get; set; }

        public Airport() { }

        public Airport(string country, string city, string airport)
        {
            Country = country;
            City = city;
            AirportName = airport;
        }

        public bool Equals(Airport obj)
        {
            if (obj == null) return false;

            bool countryEq = this.Country.Trim() == obj.Country.Trim();
            bool cityEq = this.City.Trim() == obj.City.Trim();    
            bool airportNameEq = this.AirportName.Trim().ToUpper() == obj.AirportName.Trim().ToUpper();

            return countryEq && cityEq && airportNameEq;
        }  
    }
}
