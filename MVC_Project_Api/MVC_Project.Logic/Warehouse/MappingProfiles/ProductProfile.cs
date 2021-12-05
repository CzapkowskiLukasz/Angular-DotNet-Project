using AutoMapper;
using MVC_Project.Domain.Entities;
using MVC_Project.Logic.Commons;
using MVC_Project.Logic.Warehouse.Requests;
using MVC_Project.Logic.Warehouse.Responses;
using System.Collections.Generic;

namespace MVC_Project.Logic.Warehouse.MappingProfiles
{
    public class ProductProfile : Profile
    {
        public ProductProfile()
        {
            CreateMap<Product, ProductListItem>()
                .ForMember(dest => dest.Name, opt =>
                    opt.MapFrom(src => MappingNameHelper.GetProductFullName(src)));

            CreateMap<List<Product>, GetProductListResponse>()
                .ForMember(dest => dest.Products, opt =>
                    opt.MapFrom(src => src));

            CreateMap<Product, GetProductByIdResponse>()
                .ForMember(dest => dest.CategoryName, opt =>
                    opt.MapFrom(src => src.Category.Name))
                .ForMember(dest => dest.ProducerName, opt =>
                    opt.MapFrom(src => src.Producer.Name));

            CreateMap<AddProductRequest, Product>()
                .ConvertUsing((src, dest, ctx) =>
                {
                    if (src == null || ctx == null)
                    {
                        return null;
                    }

                    dest = new();
                    dest.Name = src.Name;
                    dest.ProducerId = int.Parse(ctx.Items["producerId"].ToString());
                    dest.CategoryId = int.Parse(ctx.Items["categoryId"].ToString());
                    dest.Price = src.Price;
                    dest.WarehouseQuantity = src.Count;

                    return dest;
                });


            CreateMap<CartProduct, ProductFromOrderListItem>()
                .ForMember(dest => dest.Name, opt =>
                    opt.MapFrom(src => MappingNameHelper.GetProductFullName(src.Product)))
                .ForMember(dest => dest.PricePerItem, opt =>
                    opt.MapFrom(src => src.Product.Price))
                .ForMember(dest => dest.Count, opt =>
                    opt.MapFrom(src => src.Quantity))
                .ForMember(dest => dest.Sum, opt =>
                    opt.MapFrom(src => src.Quantity * src.Product.Price));

            CreateMap<Cart, GetProductListByOrderResponse>()
                .ConvertUsing((src, dest, ctx) =>
                {
                    if (src == null)
                    {
                        return null;
                    }

                    var cartProducts = src.CartProducts;
                    var products = ctx.Mapper.Map<List<ProductFromOrderListItem>>(cartProducts);

                    dest = new GetProductListByOrderResponse
                    {
                        Products = products,
                        Sum = src.Sum.Value,
                        Weight = src.Weight.Value
                    };

                    return dest;
                });
        }
    }
}
