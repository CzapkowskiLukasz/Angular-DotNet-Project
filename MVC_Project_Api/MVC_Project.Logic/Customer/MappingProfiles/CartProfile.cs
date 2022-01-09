using AutoMapper;
using MVC_Project.Domain.Entities;
using MVC_Project.Logic.Customer.Responses;
using System.Collections.Generic;

namespace MVC_Project.Logic.Customer.MappingProfiles
{
    public class CartProfile : Profile
    {
        public CartProfile()
        {
            //CreateMap<CartProduct, UserCartListItem>()
            //    .ForMember(dest => dest.ProductName, opt =>
            //        opt.MapFrom(src => src.Product.Name))
            //    .ForMember(dest => dest.Count, opt =>
            //        opt.MapFrom(src => src.Quantity))
            //    .ForMember(dest => dest.Price, opt =>
            //        opt.MapFrom(src => src.Price));

            CreateMap<CartProduct, UserCartListItem>()
                .ConvertUsing((src, dest) =>
                {
                    if(src == null)
                    {
                        return null;
                    }

                    dest = new UserCartListItem
                    {
                        ProductId = src.ProductId,
                        ProductName = src.Product.Name,
                        Count = src.Quantity,
                        PricePerItem = src.Product.Price,
                        Price = src.Price.Value
                    };

                    return dest;
                });

            CreateMap<List<CartProduct>, GetUserCartResponse>()
                .ForMember(dest => dest.Products, opt =>
                    opt.MapFrom(src => src));
        }
    }
}
