using AutoMapper;
using MVC_Project.Domain.Entities;
using MVC_Project.Logic.Commons;
using MVC_Project.Logic.Customer.Responses;
using System.Collections.Generic;

namespace MVC_Project.Logic.Customer.MappingProfiles
{
    public class ProductProfile : Profile
    {
        public ProductProfile()
        {
            CreateMap<Product, BestsellerListItem>()
                .ForMember(dest => dest.Name, opt =>
                    opt.MapFrom(src => MappingNameHelper.GetProductFullName(src)));

            CreateMap<List<Product>, GetBestsellersResponse>()
                .ForMember(dest => dest.Bestsellers, opt =>
                    opt.MapFrom(src => src));
        }
    }
}
