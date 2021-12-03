using AutoMapper;
using MVC_Project.Domain.Entities;
using MVC_Project.Logic.Admin.Responses;
using System.Collections.Generic;

namespace MVC_Project.Logic.Global.MappingProfiles
{
    public class CountryProfile : Profile
    {
        public CountryProfile()
        {
            CreateMap<Country, AdminCountryListItem>()
                .ForMember(dest => dest.ContinentName, opt =>
                   opt.MapFrom(src => src.Continent.Name));

            CreateMap<List<Country>, AdminGetCountryListResponse>()
                .ForMember(dest => dest.Countries, opt =>
                   opt.MapFrom(src => src));
        }
    }
}
