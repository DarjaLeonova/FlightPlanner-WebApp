﻿using FlightPlanner_WebApp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlightPlanner.Core.Services
{
    public interface IAirportService
    {
        List<Airport> SearchAirports(string q);
    }
}