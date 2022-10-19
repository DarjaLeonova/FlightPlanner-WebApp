﻿using FlightPlanner_WebApp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlightPlanner.Core.Validations.AirportValidations
{
    public interface IAirportValidator
    {
        bool IsValid(Airport airport);
    }
}
