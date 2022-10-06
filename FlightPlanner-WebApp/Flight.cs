using System;
using System.ComponentModel.DataAnnotations;

namespace FlightPlanner_WebApp
{
    public class Flight
    {
        [Key]
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
    }
}
