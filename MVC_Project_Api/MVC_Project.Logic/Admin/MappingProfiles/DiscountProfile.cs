using AutoMapper;
using MVC_Project.Domain.Entities;
using MVC_Project.Logic.Admin.Responses;
using System.Collections.Generic;

namespace MVC_Project.Logic.Global.MappingProfiles
{
    public class DiscountProfile : Profile
    {
        public DiscountProfile()
        {
            CreateMap<Discount, AdminDiscountListItem>();

            CreateMap<List<Discount>, AdminGetDiscountListResponse>()
                .ForMember(dest => dest.Discounts, opt =>
                   opt.MapFrom(src => src));
        }
    }
}
