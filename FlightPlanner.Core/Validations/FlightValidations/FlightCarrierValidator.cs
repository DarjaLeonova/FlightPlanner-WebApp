using FlightPlanner_WebApp;

namespace FlightPlanner.Core.Validations.FlightValidations
{
    public class FlightCarrierValidator : IFlightValidator
    {
        public bool IsValid(Flight flight)
        {
            return !string.IsNullOrEmpty(flight.Carrier);
        }
    }
}
