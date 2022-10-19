using FlightPlanner.Core.Models;

namespace FlightPlanner.Core.Validations.SearchFlightValidations
{
    public class SearchFlightRequestValidator : SearchFlightRequest, ISearchFlightRequestValidator
    {

        public bool AirportValidation(SearchFlightRequest request)
        {
            if (request.From == request.To) return true;
            return false;
        }

        public bool ObjectValidation(SearchFlightRequest request)
        {
            if (request.From == null || request.To == null) return true;

            var checkFrom = string.IsNullOrEmpty(request.From);
            var checkTo = string.IsNullOrEmpty(request.To);
            var checkDeparture = string.IsNullOrEmpty(request.DepartureTime);

            return checkFrom ||
                     checkTo ||
                checkDeparture;
        }
    }
}
