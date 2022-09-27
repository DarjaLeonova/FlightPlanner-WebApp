using Microsoft.AspNetCore.Mvc;

namespace FlightPlanner_WebApp.Controllers
{
    [Route("api")]
    [ApiController]
    public class CustomerApiController : ControllerBase
    {

        public static readonly object LockObject = new object();

        [Route("airports")]
        [HttpGet]
        public IActionResult GetAirport(string search)
        {
            var airport = FlightStorage.FindAirportByParameter(search);

            return Ok(airport);
        }

        [Route("flights/search")]
        [HttpPost]
        public IActionResult PostFlight(SearchFlightsRequest flightRequest)
        {
            
            if (flightRequest.ObjectValidation() || flightRequest.AirportValidation())
            {
                return BadRequest();
            }
            var matchedFlights = FlightStorage.GetMatchedFlightResult(flightRequest);

            if(matchedFlights.Items != null)
            {
                return Ok(matchedFlights);
            }else
            {
                return Ok(new SearchFlightResult());
            }   
        }

        [Route("flights/{id}")]
        [HttpGet]
        public IActionResult GetFlight(int id)
        {
            lock (LockObject) {

                var flight = FlightStorage.GetFlight(id);

                if (flight == null)
                {
                    return NotFound();
                }
                return Ok(flight);
            } 
        }
    }
}
