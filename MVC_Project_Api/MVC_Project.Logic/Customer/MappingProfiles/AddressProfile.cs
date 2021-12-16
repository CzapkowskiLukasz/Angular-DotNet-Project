using AutoMapper;
using MVC_Project.Domain.Entities;
using MVC_Project.Logic.Customer.Responses;
using System.Collections.Generic;

namespace MVC_Project.Logic.Customer.MappingProfiles
{
    public class AddressProfile : Profile
    {
        public AddressProfile()
        {

            CreateMap<Address, AddressListItem>()
    .ForMember(dest => dest.Street, opt =>
        opt.MapFrom(src => src.Street));


            CreateMap<List<Address>, GetAddressesResponse>()
    .ForMember(dest => dest.Addresses, opt =>
        opt.MapFrom(src => src));
        }
    }
}
