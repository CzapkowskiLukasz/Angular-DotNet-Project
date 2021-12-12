using AutoMapper;
using MVC_Project.Domain.Entities;
using MVC_Project.Logic.Admin.Requests;
using MVC_Project.Logic.Admin.Responses;
using MVC_Project.Logic.Commons;
using System;
using System.Collections.Generic;

namespace MVC_Project.Logic.Admin.MappingProfiles
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

            CreateMap<AdminAddProductRequest, Product>()
                .ForMember(dest => dest.WarehouseQuantity, opt =>
                    opt.MapFrom(src => src.Count))
                .ForMember(dest => dest.CreateDate, opt =>
                    opt.MapFrom(src => DateTime.UtcNow));


            // Update

            CreateMap<AdminUpdateProductRequest, Product>()
                .ConvertUsing((src, dest) =>
                {
                    if (src == null)
                        return null;

                    dest.Name = src.Name;
                    dest.ProducerId = src.ProducerId;
                    dest.Description = src.Description;
                    dest.Price = src.Price;
                    dest.WarehouseQuantity = src.Count;
                    dest.CategoryId = src.CategoryId;

                    return dest;
                });

            CreateMap<Product, AdminUpdateProductResponse>();
        }
    }
}
