using AutoMapper;
using MVC_Project.Domain.Entities;
using MVC_Project.Logic.Customer.Requests;

namespace MVC_Project.Logic.Customer.MappingProfiles
{
    public class AddressProfile : Profile
    {
        public AddressProfile()
        {
            CreateMap<AddAddressRequest, Address>()
                .ForMember(dest => dest.BuildingNumber, opt =>
                    opt.MapFrom(src => src.HouseNumber))
                .ForMember(dest => dest.ZipCode, opt =>
                    opt.MapFrom(src => src.Code));
        }
    }
}
