using FlightPlanner.Core.Services;

namespace FlightPlanner.Core.Models
{
    public abstract class Entity : IEntity
    {      
        public int Id { get; set; }
    }
}
