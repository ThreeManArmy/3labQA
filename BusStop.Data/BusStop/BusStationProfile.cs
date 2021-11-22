using AutoMapper;

namespace BusStop.Data.BusStop
{
    public class DaoBusStationProfile : Profile
    {
        public DaoBusStationProfile()
        {
            CreateMap<Core.BusStop.BusStop, BusDto>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
                .ForMember(dest => dest.Location, opt => opt.MapFrom(src => src.Location))
                .ForMember(dest => dest.Location, opt => opt.MapFrom(src => src.Location))
                .ForMember(dest => dest.CountOfBuses, opt => opt.MapFrom(src => src.CountOfBuses))
                .ReverseMap();
        }
    }
}