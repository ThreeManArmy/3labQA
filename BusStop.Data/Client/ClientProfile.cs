using AutoMapper;

namespace BusStop.Data.Client
{
    public class DaoClientProfile : Profile
    {
        public DaoClientProfile()
        {
            CreateMap<Core.Client.Client, ClientDto>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
                .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name))
                .ForMember(dest => dest.SecondName, opt => opt.MapFrom(src => src.SecondName))
                .ForMember(dest => dest.CountOfTravels, opt => opt.MapFrom(src => src.CountOfTravels))
                .ReverseMap();
        }

    }
}