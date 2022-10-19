using AutoMapper;
using FlightPlanner_WebApp.Models;

namespace FlightPlanner_WebApp
{
    public class MapperConfigcs
    {
        public static IMapper CreateMapper()
        {
            var config = new MapperConfiguration(
                cfg =>
                {
                    cfg.CreateMap<AirportRequest, Airport>()
                        .ForMember(d => d.Id, options => options.Ignore()
                        )
                        .ForMember(d => d.AirportName, opt => opt.MapFrom(s => s.Airport));
                    cfg.CreateMap<Airport, AirportRequest>()
                        .ForMember(d => d.Airport, opt => opt.MapFrom(s => s.AirportName));
                    cfg.CreateMap<FlightRequest, Flight>();
                    cfg.CreateMap<Flight, FlightRequest>();
                });

            config.AssertConfigurationIsValid();
            return config.CreateMapper();
        }
    }
}
