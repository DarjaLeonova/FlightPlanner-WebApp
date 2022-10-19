using FlightPlanner_WebApp;

namespace FlightPlanner.Core.Validations.AirportValidations
{
    public class AirportCountryValidator : IAirportValidator
    {
        public bool IsValid(Airport airport)
        {
            return !string.IsNullOrEmpty(airport.Country);
        }
    }
}
