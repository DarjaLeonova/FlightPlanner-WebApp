using FlightPlanner_WebApp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlightPlanner.Core.Validations.FlightValidations
{
    public class FlightTimeValidator : IFlightValidator
    {
        public bool IsValid(Flight flight)
        {
            if (!string.IsNullOrEmpty(flight?.DepartureTime) &&
                !string.IsNullOrEmpty(flight?.ArrivalTime)) 
            {
                var departure = DateTime.Parse(flight.DepartureTime);
                var arrival = DateTime.Parse(flight.ArrivalTime);
                return departure < arrival;
            }
            return false;

            
        }
    }
}
