using AutoMapper;
using MVC_Project.Domain.Entities;
using MVC_Project.Logic.Admin.Responses;
using MVC_Project.Logic.Commons;
using System.Collections.Generic;

namespace MVC_Project.Logic.Global.MappingProfiles
{
    public class ProductProfile : Profile
    {
        public ProductProfile()
        {
            CreateMap<Product, AdminProductListItem>()
                .ForMember(dest => dest.Name, opt =>
                    opt.MapFrom(src => MappingNameHelper.GetProductFullName(src)))
                .ForMember(dest => dest.Count, opt =>
                    opt.MapFrom(src => src.WarehouseQuantity));

            CreateMap<List<Product>, AdminGetProductListResponse>()
                .ForMember(dest => dest.Products, opt =>
                    opt.MapFrom(src => src));
        }
    }
}
