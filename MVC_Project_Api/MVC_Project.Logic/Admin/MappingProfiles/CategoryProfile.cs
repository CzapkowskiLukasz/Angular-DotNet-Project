using AutoMapper;
using MVC_Project.Domain.Entities;
using MVC_Project.Logic.Admin.Responses;
using System.Collections.Generic;

namespace MVC_Project.Logic.Global.MappingProfiles
{
    public class CategoryProfile : Profile
    {
        public CategoryProfile()
        {
            CreateMap<Category, AdminCategoryListItem>();

            CreateMap<List<Category>, AdminGetCategoryListResponse>()
                .ForMember(dest => dest.Categories, opt =>
                   opt.MapFrom(src => src));
        }
    }
}
