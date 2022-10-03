namespace FlightPlanner_WebApp.Validations.AirportValidations
{
    public class AirportValidations 
    {
        public static bool ObjectValidation(Airport airport)
        {
            var checkCountry = string.IsNullOrEmpty(airport.Country);
            var checkCity = string.IsNullOrEmpty(airport.City);
            var checkAirportName = string.IsNullOrEmpty(airport.AirportName);

            return checkCountry || checkCity || checkAirportName;
        }

        public static bool SameAirportValidation(Airport existingAirport, Airport newAirport)
        {
            return existingAirport.AirportName.Trim().ToUpper() == newAirport.AirportName.Trim().ToUpper();
        }
    }
}
