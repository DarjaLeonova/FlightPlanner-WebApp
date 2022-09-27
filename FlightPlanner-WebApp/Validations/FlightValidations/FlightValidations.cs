using System;

namespace FlightPlanner_WebApp.Validations.FlightValidations
{
    public class FlightValidations
    {
        public static bool ObjectValidation(Flight flight)
        {
            if (flight.From == null || flight.To == null) return true;

            var checkFrom = AirportValidations.AirportValidations.ObjectValidation(flight.From);
            var checkTo = AirportValidations.AirportValidations.ObjectValidation(flight.To);
            var checkCarrier = string.IsNullOrEmpty(flight.Carrier);
            var checkDeparture = string.IsNullOrEmpty(flight.DepartureTime);
            var checkArrival = string.IsNullOrEmpty(flight.ArrivalTime);

            return checkFrom ||
                checkTo ||
                checkCarrier ||
                checkDeparture ||
                checkArrival;
        }

        public static bool NotValidDateTimeValidation(Flight flight)
        {
            var departureTime = DateTime.Parse(flight.DepartureTime);
            var arrivalTime = DateTime.Parse(flight.ArrivalTime);

            if (arrivalTime <= departureTime)
            {
                return false;
            }
            else
            {
                return true;
            }
        }
    }
}
