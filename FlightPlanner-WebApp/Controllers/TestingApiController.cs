using FlightPlanner_WebApp.Data;
using Microsoft.AspNetCore.Mvc;

namespace FlightPlanner_WebApp.Controllers
{
    [Route("testing-api")]
    [ApiController]
    public class TestingApiController : ControllerBase
    {
        private readonly FlightPlannerDbContext _db;
        private FlightStorage _flightStorage;

        public TestingApiController(FlightPlannerDbContext db)
        {
            _db = db;
            _flightStorage = new FlightStorage(_db);
        }

        [HttpPost]
        [Route ("clear")]
        public IActionResult Clear()
        {
            _flightStorage.Clear();
            return Ok();
        }
    }
}
