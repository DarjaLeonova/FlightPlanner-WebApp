using FlightPlanner_WebApp.Data;
using Microsoft.AspNetCore.Mvc;

namespace FlightPlanner_WebApp.Controllers
{
    [Route("api")]
    [ApiController]
    public class CustomerApiController : ControllerBase
    {
        public static readonly object LockObject = new object();
        private readonly FlightPlannerDbContext _db;
        private FlightStorage _flightStorage;

        public CustomerApiController(FlightPlannerDbContext db)
        {
            _db = db;
            _flightStorage = new FlightStorage(_db);
        }

        [Route("airports")]
        [HttpGet]
        public IActionResult GetAirport(string search)
        {
            var airport = _flightStorage.FindAirportByParameter(search);
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

                var flight = _flightStorage.GetFlight(id);

                if (flight == null)
                {
                    return NotFound();
                }
                return Ok(flight);
            } 
        }
    }
}
