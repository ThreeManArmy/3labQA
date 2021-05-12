using AutoMapper;

namespace BusStop.Onion.BusContract
{
    public class BusStationProfile : Profile
    {
        public BusStationProfile()
        {
            CreateMap<Core.BusStop.BusStop, Bus>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
                .ForMember(dest => dest.Location, opt => opt.MapFrom(src => src.Location))
                .ForMember(dest => dest.Location, opt => opt.MapFrom(src => src.Location))
                .ForMember(dest => dest.CountOfBuses, opt => opt.MapFrom(src => src.CountOfBuses));
        }
    }
}