﻿using AutoMapper;
using MVC_Project.Domain.Entities;
using MVC_Project.Logic.Admin.Responses;
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
        }
    }
}
