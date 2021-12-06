using AutoMapper;
using MVC_Project.Domain.Entities;
using MVC_Project.Logic.Admin.Requests;
using MVC_Project.Logic.Admin.Responses;
using System.Collections.Generic;

namespace MVC_Project.Logic.Global.MappingProfiles
{
    public class ProducerProfile : Profile
    {
        public ProducerProfile()
        {
            CreateMap<Producer, AdminProducerListItem>()
                .ForMember(dest => dest.CountryName, opt =>
                   opt.MapFrom(src => src.Country.Name));

            CreateMap<List<Producer>, AdminGetProducerListResponse>()
                .ForMember(dest => dest.Producers, opt =>
                   opt.MapFrom(src => src));

            CreateMap<Producer, AdminProducerDropdownListItem>();

            CreateMap<List<Producer>, AdminGetProducerDropdownListResponse>()
                .ForMember(dest => dest.Producers, opt =>
                   opt.MapFrom(src => src));

            CreateMap<AddProducerRequest, Producer>();

            CreateMap<Producer, AddProducerResponse>();
        }
    }
}
