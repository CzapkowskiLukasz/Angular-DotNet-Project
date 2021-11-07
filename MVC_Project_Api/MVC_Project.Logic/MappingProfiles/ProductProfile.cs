using AutoMapper;
using MVC_Project.Domain.Entities;
using MVC_Project.Logic.Responses;
using System.Collections.Generic;

namespace MVC_Project.Logic.MappingProfiles
{
    public class ProductProfile : Profile
    {
        public ProductProfile()
        {
            CreateMap<Product, ProductListItem>();

            CreateMap<List<Product>, GetProductListResponse>()
                .ForMember(dest => dest.Products, opt =>
                    opt.MapFrom(src => src));

            CreateMap<Product, GetProductByIdResponse>()
                .ForMember(dest => dest.CategoryName, opt =>
                    opt.MapFrom(src => src.Category.Name))
                .ForMember(dest => dest.ProducerName, opt =>
                    opt.MapFrom(src => src.Producer.Name));
        }
    }
}
