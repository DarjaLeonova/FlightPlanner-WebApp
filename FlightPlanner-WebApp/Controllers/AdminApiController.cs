using AutoMapper;
using FlightPlanner.Core.Services;
using FlightPlanner.Core.Validations.AirportValidations;
using FlightPlanner.Core.Validations.FlightValidations;
using FlightPlanner_WebApp.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

namespace FlightPlanner_WebApp.Controllers
{
    [Route("admin-api")]
    [ApiController, Authorize]
    public class AdminApiController : ControllerBase
    {
        public static readonly object LockObject = new object();
        private readonly IFlightService _flightService;
        private readonly IEnumerable<IFlightValidator> _flightValidators;
        private readonly IEnumerable<IAirportValidator> _airportValidators;
        private readonly IMapper _mapper;

        public AdminApiController(IFlightService flightService, 
            IEnumerable<IFlightValidator> flightValidators,
            IEnumerable<IAirportValidator> airportValidators,
            IMapper mapper)
        {
            _flightService = flightService;
            _flightValidators = flightValidators;
            _airportValidators = airportValidators;
            _mapper = mapper;
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
            return Ok(flight);
        }

        [Route("flights")]
        [HttpPut]
        public IActionResult PutFlight(Flight flight)
        {
            lock (LockObject)
            {
                if (_flightService.Exists(flight))
                {
                    return Conflict();
                }

                if (!_flightValidators.All(f => f.IsValid(flight)) ||
                   ! _airportValidators.All(f => f.IsValid(flight?.From)) ||
                   ! _airportValidators.All(f => f.IsValid(flight?.To)))
                {
                    return BadRequest();
                }
                var result = _flightService.Create(flight);
                var response = _mapper.Map<FlightRequest>(flight);
               
                return Created("", response);
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
