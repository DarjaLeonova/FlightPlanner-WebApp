using FlightPlanner.Core.Models;
using FlightPlanner_WebApp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlightPlanner.Core.Validations.SearchFlightValidations
{
    public interface ISearchFlightRequestValidator
    {
        public bool ObjectValidation(SearchFlightRequest request);

        public bool AirportValidation(SearchFlightRequest request);
    }
}
