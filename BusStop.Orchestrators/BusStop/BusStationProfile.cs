using AutoMapper;

namespace BusStop.Orchestrators.BusStop
{
    public class OrchBusStationProfile : Profile
    {
        public OrchBusStationProfile()
        {
            CreateMap<Core.BusStop.BusStop, Bus>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
                .ForMember(dest => dest.Location, opt => opt.MapFrom(src => src.Location))
                .ForMember(dest => dest.Location, opt => opt.MapFrom(src => src.Location))
                .ForMember(dest => dest.CountOfBuses, opt => opt.MapFrom(src => src.CountOfBuses))
                .ReverseMap();
        }
    }
}