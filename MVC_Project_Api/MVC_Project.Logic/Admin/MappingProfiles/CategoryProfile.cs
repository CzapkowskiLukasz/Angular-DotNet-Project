using AutoMapper;
using MVC_Project.Domain.Entities;
using MVC_Project.Logic.Admin.Requests;
using MVC_Project.Logic.Admin.Responses;
using System.Collections.Generic;

namespace MVC_Project.Logic.Global.MappingProfiles
{
    public class CategoryProfile : Profile
    {
        public CategoryProfile()
        {
            // Get dropdown list

            CreateMap<Category, AdminCategoryDropdownListItem>();

            CreateMap<List<Category>, AdminGetCategoryDropdownListResponse>()
                .ForMember(dest => dest.Categories, opt =>
                   opt.MapFrom(src => src));


            // Get list

            CreateMap<Category, AdminCategoryListItem>()
                .ForMember(dest => dest.ParentId, opt =>
                   opt.MapFrom(src => src.ParentCategoryId))
                .ForMember(dest => dest.ParentName, opt =>
                   opt.MapFrom(src => src.ParentCategory.Name));

            CreateMap<List<Category>, AdminGetCategoryListResponse>()
                .ForMember(dest => dest.Categories, opt =>
                   opt.MapFrom(src => src));


            // Add category

            CreateMap<AddCategoryRequest, Category>()
                .ForMember(dest => dest.ParentCategoryId, opt =>
                   opt.MapFrom(src => ConvertParentId(src.ParentId)));

            CreateMap<Category, AddCategoryResponse>();
        }

        private int? ConvertParentId(int parentId) =>
            parentId == 0 ? null : parentId;
    }
}
