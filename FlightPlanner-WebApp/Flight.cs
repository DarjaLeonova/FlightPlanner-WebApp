using System;

namespace FlightPlanner_WebApp
{
    public class Flight
    {
        public int Id { get; set; }
        public Airport From { get; set; }
        public Airport To { get; set; }
        public string Carrier { get; set; }
        public string DepartureTime { get; set; }
        public string ArrivalTime { get; set; }
        public bool Equals(Flight obj)
        {
            if (obj == null) return false;
            bool fromEq = this.From.Equals(obj.From);
            bool toEq = this.To.Equals(obj.To);
            bool carrierEq = this.Carrier == obj.Carrier;
            bool departureTimeEq = this.DepartureTime == obj.DepartureTime; 
            bool arrivalTimeEq = this.ArrivalTime == obj.ArrivalTime;

            return fromEq && toEq && carrierEq && departureTimeEq && arrivalTimeEq;
        }

        public bool ObjectValidation()
        {
            if (From  == null || To == null) return true;
            var checkFrom = From.ObjectValidation();
            var checkTo = To.ObjectValidation();
            var checkCarrier = string.IsNullOrEmpty(Carrier) ;
            var checkDeparture = string.IsNullOrEmpty(DepartureTime);
            var checkArrival = string.IsNullOrEmpty(ArrivalTime);

            return checkFrom || 
                checkTo || 
                checkCarrier || 
                checkDeparture || 
                checkArrival;
        }

        public bool NotValidDateTime(Flight flight)
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
