using FlightPlanner.Core.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace FlightPlanner.Core.Models
{
    public abstract class Entity : IEntity
    {      
        public int Id { get; set; }
    }
}
