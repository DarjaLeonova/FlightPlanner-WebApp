using FlightPlanner_WebApp;

namespace FlightPlanner.Core.Validations.FlightValidations
{
    public interface IFlightValidator
    {
        bool IsValid(Flight flight);
    }
}
