using FlightPlanner_WebApp;

namespace FlightPlanner.Core.Validations.AirportValidations
{
    public interface IAirportValidator
    {
        bool IsValid(Airport airport);
    }
}
