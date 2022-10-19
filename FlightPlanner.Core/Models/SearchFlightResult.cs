using FlightPlanner_WebApp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlightPlanner.Core.Models
{
    public class SearchFlightResult
    {
        public List<Flight>? Items { get; set; }
        public int Page { get; set; }
        public int TotalItems { get; set; }
    }
}
