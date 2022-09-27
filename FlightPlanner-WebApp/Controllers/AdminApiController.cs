using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FlightPlanner_WebApp.Controllers
{
    [Route("admin-api")]
    [ApiController, Authorize]
    public class AdminApiController : ControllerBase
    {
        public static readonly object LockObject = new object();

        [Route("flights/{id}")]
        [HttpGet]
        public IActionResult GetFlight(int id)
        {
            var flight = FlightStorage.GetFlight(id);
            if(flight == null)
            {
                return NotFound();
            }
            return Ok(flight);
        }

        [Route("flights")]
        [HttpPut]
        public IActionResult PutFlight(Flight flight)
        {
            // if (flight == null) return NoContent();
            lock (LockObject)
            {
                if (FlightStorage.FlightExist(flight))
                {
                    return Conflict();
                }

                if (flight.ObjectValidation() || flight.From.SameAirportValidation(flight.To) || !flight.NotValidDateTime(flight))
                {
                    return BadRequest();
                }

                flight = FlightStorage.AddFlight(flight);



                return Created("", flight);
            }
            



        }

        [Route("flights/{id}")]
        [HttpDelete]
        public IActionResult DeleteFlight(int id)
        {
            lock (LockObject)
            {
                FlightStorage.DeleteFlight(id);
                return Ok();
            }
            
        }
    }
}
