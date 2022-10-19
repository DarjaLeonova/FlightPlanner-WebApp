﻿using FlightPlanner_WebApp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlightPlanner.Core.Validations.FlightValidations
{
    public interface IFlightValidator
    {
        bool IsValid(Flight flight);
    }
}
