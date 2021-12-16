using AutoMapper;
using MVC_Project.Domain.Entities;
using MVC_Project.Logic.Admin.Responses;
using MVC_Project.Logic.Global.Requests;
using System.Collections.Generic;

namespace MVC_Project.Logic.Admin.MappingProfiles
{
    public class UserProfile : Profile
    {
        public UserProfile()
        {
            CreateMap<User, AdminUserListItem>()
                .ForMember(dest => dest.UserId, opt =>
                   opt.MapFrom(src => src.Id));

            CreateMap<List<User>, AdminGetUserListResponse>()
                .ForMember(dest => dest.Users, opt =>
                   opt.MapFrom(src => src));

            CreateMap<User, AdminGetUserById>()
                .ForMember(dest => dest.UserId, opt =>
                   opt.MapFrom(src => src.Id));

            CreateMap<RegisterRequest, User>()
                .ForMember(dest => dest.ThemeId, opt =>
                   opt.MapFrom(src => 1))
                .ForMember(dest => dest.ProductOnPageCount, opt =>
                   opt.MapFrom(src => 0))
                .ForMember(dest => dest.Provider, opt =>
                   opt.MapFrom(src => 1));
        }
    }
}
