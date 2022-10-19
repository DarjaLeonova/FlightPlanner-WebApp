using FlightPlanner.Core.Services;
using FlightPlanner_WebApp.Data;
using Microsoft.AspNetCore.Mvc;

namespace FlightPlanner_WebApp.Controllers
{
    [Route("testing-api")]
    [ApiController]
    public class TestingApiController : ControllerBase
    {
        private readonly FlightPlannerDbContext _db;
        //private FlightStorage _flightStorage;
        private readonly IFlightService _flightService;

        public TestingApiController(IFlightService flightService)
        {
            _flightService = flightService;
        }

        [HttpPost]
        [Route ("clear")]
        public IActionResult Clear()
        {
            _flightService.DeleteAll();
            return Ok();
        }
    }
}
