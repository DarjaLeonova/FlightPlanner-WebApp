using FlightPlanner_WebApp;

namespace FlightPlanner.Core.Validations.FlightValidations
{
    public class FlightAirportValidator : IFlightValidator
    { 
        public bool IsValid(Flight flight)
        {
            if (flight.From == null || flight.To == null) return false;

            return flight.From.AirportName.Trim().ToLower() != flight.To.AirportName.Trim().ToLower();
        }
    }
}
