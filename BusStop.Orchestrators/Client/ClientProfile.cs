using AutoMapper;

namespace BusStop.Orchestrators.Client
{
    public class OrchClientProfile : Profile
    {
        public OrchClientProfile()
        {
            CreateMap<Core.Client.Client, Client>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
                .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name))
                .ForMember(dest => dest.SecondName, opt => opt.MapFrom(src => src.SecondName))
                .ForMember(dest => dest.CountOfTravels, opt => opt.MapFrom(src => src.CountOfTravels))
                .ReverseMap();
        }

    }
}