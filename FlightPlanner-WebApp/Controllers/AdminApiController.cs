using FlightPlanner.Core.Services;
using FlightPlanner_WebApp.Data;
using FlightPlanner_WebApp.Validations.AirportValidations;
using FlightPlanner_WebApp.Validations.FlightValidations;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace FlightPlanner_WebApp.Controllers
{
    [Route("admin-api")]
    [ApiController, Authorize]
    public class AdminApiController : ControllerBase
    {
        public static readonly object LockObject = new object();
        private readonly IFlightService _flightService;
        private FlightStorage _flightStorage;

        public AdminApiController(IFlightService flightService)
        {
            _flightService = flightService;
            //_flightStorage = new FlightStorage(_db);
        }

        [Route("flights/{id}")]
        [HttpGet]
        public IActionResult GetFlight(int id)
        {
            var flight = _flightService.GetCompleteFlightById(id);

            if(flight == null)
            {
                return NotFound();
            }
            return Ok(_flightStorage);
        }

        [Route("flights")]
        [HttpPut]
        public IActionResult PutFlight(Flight flight)
        {
            lock (LockObject)
            {
                if (_flightStorage.FlightExist(flight))
                {
                    return Conflict();
                }

               if (FlightValidations.ObjectValidation(flight) ||
                    AirportValidations.SameAirportValidation(flight.To, flight.From) ||
                    !FlightValidations.NotValidDateTimeValidation(flight))
                {
                    return BadRequest();
                }

                _flightService.Create(flight);

                return Created("", flight);
            }
        }

        [Route("flights/{id}")]
        [HttpDelete]
        public IActionResult DeleteFlight(int id)
        {
            lock (LockObject)
            {
                var flight = _flightService.GetById(id);
                if(flight != null)
                {
                    _flightService.Delete(flight);
                }
                return Ok();
            }
        }
    }
}
