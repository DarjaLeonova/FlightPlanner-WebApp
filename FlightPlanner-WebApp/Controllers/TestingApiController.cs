﻿using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FlightPlanner_WebApp.Controllers
{
    [Route("testing-api")]
    [ApiController]
    public class TestingApiController : ControllerBase
    {
        [HttpPost]
        [Route ("clear")]
        public IActionResult Clear()
        {
            FlightStorage.Clear();
            return Ok();
        }
    }
}
