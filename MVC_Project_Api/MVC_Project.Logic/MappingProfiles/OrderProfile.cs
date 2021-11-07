using AutoMapper;
using MVC_Project.Domain.Entities;
using MVC_Project.Logic.Responses;
using System.Collections.Generic;

namespace MVC_Project.Logic.MappingProfiles
{
    public class OrderProfile : Profile
    {
        public OrderProfile()
        {
            CreateMap<Order, OrderListItem>()
                .ForMember(dest => dest.Status, opt =>
                    opt.MapFrom(src => src.OrderStatus.Name))
                .ForMember(dest => dest.Date, opt =>
                    opt.MapFrom(src => $"{src.Date.Day}.{src.Date.Month}.{src.Date.Year}"));

            CreateMap<List<Order>, GetOrderListResponse>()
                .ForMember(dest => dest.Orders, opt =>
                    opt.MapFrom(src => src));
        }
    }
}
