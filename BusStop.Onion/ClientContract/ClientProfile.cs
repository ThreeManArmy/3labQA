using AutoMapper;

namespace BusStop.Onion.ClientContract
{
    public class ClientProfile : Profile
    {
        public ClientProfile()
        {
            CreateMap<Core.Client.Client, Client>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
                .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name))
                .ForMember(dest => dest.SecondName, opt => opt.MapFrom(src => src.SecondName))
                .ForMember(dest => dest.CountOfTravels, opt => opt.MapFrom(src => src.CountOfTravels));
        }

    }
}