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
            CreateMap<Order, OrderListItem>();

            CreateMap<List<Order>, GetOrderListResponse>()
                .ForMember(dest => dest.Orders, opt =>
                    opt.MapFrom(src => src));
        }
    }
}
