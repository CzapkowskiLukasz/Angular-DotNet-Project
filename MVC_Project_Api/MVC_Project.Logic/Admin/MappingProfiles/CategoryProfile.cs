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
            CreateMap<Category, AdminCategoryDropdownListItem>();

            CreateMap<List<Category>, AdminGetCategoryDropdownListResponse>()
                .ForMember(dest => dest.Categories, opt =>
                   opt.MapFrom(src => src));

            CreateMap<Category, AdminCategoryListItem>()
                .ForMember(dest => dest.ParentId, opt =>
                   opt.MapFrom(src => src.ParentCategoryId))
                .ForMember(dest => dest.ParentName, opt =>
                   opt.MapFrom(src => src.ParentCategory.Name));

            CreateMap<List<Category>, AdminGetCategoryListResponse>()
                .ForMember(dest => dest.Categories, opt =>
                   opt.MapFrom(src => src));
        }
    }
}
