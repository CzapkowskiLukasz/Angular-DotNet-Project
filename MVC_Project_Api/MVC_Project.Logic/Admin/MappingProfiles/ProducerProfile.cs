using AutoMapper;
using MVC_Project.Domain.Entities;
using MVC_Project.Logic.Admin.Requests;
using MVC_Project.Logic.Admin.Responses;
using System.Collections.Generic;

namespace MVC_Project.Logic.Admin.MappingProfiles
{
    public class ProducerProfile : Profile
    {
        public ProducerProfile()
        {
            // Get list

            CreateMap<Producer, AdminProducerListItem>()
                .ForMember(dest => dest.CountryName, opt =>
                   opt.MapFrom(src => src.Country.Name));

            CreateMap<List<Producer>, AdminGetProducerListResponse>()
                .ForMember(dest => dest.Producers, opt =>
                   opt.MapFrom(src => src));


            // Get dropdown list

            CreateMap<Producer, AdminProducerDropdownListItem>();

            CreateMap<List<Producer>, AdminGetProducerDropdownListResponse>()
                .ForMember(dest => dest.Producers, opt =>
                   opt.MapFrom(src => src));


            // Add

            CreateMap<AddProducerRequest, Producer>();

            CreateMap<Producer, AddProducerResponse>();


            // Update

            CreateMap<UpdateProducerRequest, Producer>()
                .ConvertUsing((src, dest) =>
                {
                    if (src == null)
                        return null;

                    dest.Name = src.Name;
                    dest.CountryId = src.CountryId;

                    return dest;
                });

            CreateMap<Producer, UpdateProducerResponse>();
        }
    }
}
