using AutoMapper;
using MVC_Project.Domain.Entities;
using MVC_Project.Logic.Global.Responses;

namespace MVC_Project.Logic.Global.MappingProfiles
{
    public class CountryProfile : Profile
    {
        public CountryProfile()
        {
            CreateMap<Country, GetCountryByIdResponse>()
                .ForMember(dest => dest.ContinentName, opt =>
                  opt.MapFrom(src => src.Continent.Name));
        }
    }
}
