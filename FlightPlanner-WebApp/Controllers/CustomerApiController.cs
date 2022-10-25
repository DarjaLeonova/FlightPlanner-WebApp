using AutoMapper;
using FlightPlanner.Core.Models;
using FlightPlanner.Core.Services;
using FlightPlanner.Core.Validations.SearchFlightValidations;
using FlightPlanner_WebApp.Models;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace FlightPlanner_WebApp.Controllers
{
    [Route("api")]
    [ApiController]
    public class CustomerApiController : ControllerBase
    {
        public static readonly object LockObject = new object();
        private readonly IFlightService _flightService;
        private readonly IAirportService _airportService;
        private readonly ISearchFlightRequestValidator _searchFlightRequestValidator;
        private readonly IMapper _mapper;

        public CustomerApiController(
            IFlightService flightService,
            ISearchFlightRequestValidator searchFlightRequestValidator,
            IMapper mapper,
            IAirportService airportService)
        {
            _searchFlightRequestValidator = searchFlightRequestValidator;
            _flightService = flightService;
            _mapper = mapper;
            _airportService = airportService;
        }

        [Route("airports")]
        [HttpGet]
        public IActionResult GetAirport(string search)
        {
            search = search.Trim().ToLower();

            var airport = _airportService.SearchAirports(search);
            var response = airport.Select(x => _mapper.Map<AirportRequest>(x)).ToList();

            return Ok(response);
        }

        [Route("flights/search")]
        [HttpPost]
        public IActionResult PostFlight(SearchFlightRequest request)
        {  
            if (_searchFlightRequestValidator.ObjectValidation(request) || _searchFlightRequestValidator.AirportValidation(request))
            {
                return BadRequest();
            }
            var matchedFlights = _flightService.SearchFlightsByRequest(request.To, request.From, request.DepartureTime);

            return Ok(matchedFlights);
        }

        [Route("flights/{id}")]
        [HttpGet]
        public IActionResult GetFlight(int id)
        {
            lock (LockObject) {

                var flight = _flightService.GetCompleteFlightById(id);

                if (flight == null)
                {
                    return NotFound();
                }
                var response = _mapper.Map<FlightRequest>(flight);

                return Ok(response);
            } 
        }
    }
}
