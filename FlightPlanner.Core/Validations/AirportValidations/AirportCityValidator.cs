using FlightPlanner_WebApp;

namespace FlightPlanner.Core.Validations.AirportValidations
{
    public class AirportCityValidator : IAirportValidator
    {
        public bool IsValid(Airport airport)
        {
            return !string.IsNullOrEmpty(airport.City);
        }
    }
}

    
