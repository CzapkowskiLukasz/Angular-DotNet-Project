using AutoMapper;
using MVC_Project.Domain.Entities;
using MVC_Project.Logic.Admin.Requests;
using MVC_Project.Logic.Admin.Responses;
using System.Collections.Generic;

namespace MVC_Project.Logic.Global.MappingProfiles
{
    public class CountryProfile : Profile
    {
        public CountryProfile()
        {
            // Get list

            CreateMap<Country, AdminCountryListItem>()
                .ForMember(dest => dest.ContinentName, opt =>
                   opt.MapFrom(src => src.Continent.Name));

            CreateMap<List<Country>, AdminGetCountryListResponse>()
                .ForMember(dest => dest.Countries, opt =>
                   opt.MapFrom(src => src));


            // Get dropdown list

            CreateMap<Country, AdminCountryDropdownListItem>();

            CreateMap<List<Country>, AdminGetCountryDropdownListResponse>()
                .ForMember(dest => dest.Countries, opt =>
                   opt.MapFrom(src => src));

            // Add

            CreateMap<AddCountryRequest, Country>();

            CreateMap<Country, AddCountryResponse>();
        }
    }
}
