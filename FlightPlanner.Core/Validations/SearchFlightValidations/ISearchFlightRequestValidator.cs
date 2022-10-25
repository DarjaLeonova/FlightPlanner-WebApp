using FlightPlanner.Core.Models;

namespace FlightPlanner.Core.Validations.SearchFlightValidations
{
    public interface ISearchFlightRequestValidator
    {
        public bool ObjectValidation(SearchFlightRequest request);

        public bool AirportValidation(SearchFlightRequest request);
    }
}
