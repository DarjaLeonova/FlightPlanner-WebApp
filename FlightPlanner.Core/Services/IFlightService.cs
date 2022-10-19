using FlightPlanner.Core.Models;
using FlightPlanner_WebApp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlightPlanner.Core.Services
{
    public interface IFlightService : IEntityService<Flight>
    {
        Flight GetCompleteFlightById(int id);
        bool Exists(Flight flight);
        List<Airport> SearchAirports(string q);
        SearchFlightResult SearchFlightsByRequest(string from, string to, string departure);

        public void DeleteAll();
    }
}
