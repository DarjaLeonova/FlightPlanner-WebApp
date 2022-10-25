using FlightPlanner.Core.Services;
using Microsoft.AspNetCore.Mvc;

namespace FlightPlanner_WebApp.Controllers
{
    [Route("testing-api")]
    [ApiController]
    public class TestingApiController : ControllerBase
    {
        private readonly IFlightService _flightService;
        private readonly IDbService _dbService;

        public TestingApiController(IFlightService flightService, IDbService dbService)
        {
            _flightService = flightService;
            _dbService = dbService;
        }

        [HttpPost]
        [Route ("clear")]
        public IActionResult Clear()
        {
            _dbService.DeleteAll<Flight>();
            _dbService.DeleteAll<Airport>();
            return Ok();
        }
    }
}
