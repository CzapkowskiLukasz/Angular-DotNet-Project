using AutoMapper;
using MVC_Project.Domain.Entities;
using MVC_Project.Logic.Warehouse.Responses;
using System;
using System.Collections.Generic;

namespace MVC_Project.Logic.Warehouse.MappingProfiles
{
    public class OrderProfile : Profile
    {
        public OrderProfile()
        {
            CreateMap<Order, OrderListItem>()
                .ForMember(dest => dest.Status, opt =>
                    opt.MapFrom(src => src.OrderStatus.Name))
                .ForMember(dest => dest.Date, opt =>
                    opt.MapFrom(src => ConvertDate(src.Date)))
                .ForMember(dest => dest.UserName, opt =>
                    opt.MapFrom(src => $"{src.User.Name} {src.User.Surname}"));

            CreateMap<List<Order>, GetOrderListResponse>()
                .ForMember(dest => dest.Orders, opt =>
                    opt.MapFrom(src => src));

            CreateMap<Order, GetOrderByIdResponse>()
                .ForMember(dest => dest.UserName, opt =>
                    opt.MapFrom(src => GetUserName(src.User)))
                .ForMember(dest => dest.UserEmail, opt =>
                    opt.MapFrom(src => src.User.Email))
                .ForMember(dest => dest.UserPhoneNumber, opt =>
                    opt.MapFrom(src => src.User.PhoneNumber))
                .ForMember(dest => dest.AddressInOneString, opt =>
                    opt.MapFrom(src => ConvertAddressToOneLine(src.Address)))
                .ForMember(dest => dest.Status, opt =>
                    opt.MapFrom(src => src.OrderStatus.Name))
                .ForMember(dest => dest.Date, opt =>
                    opt.MapFrom(src => ConvertDate(src.Date)));
        }

        private string ConvertDate(DateTime date)
        {
            string day = date.Date.Day.ToString();
            if (day.Length == 1)
                day.Insert(0, "0");

            return $"{day}/{date.Date.Month}/{date.Date.Year}";
        }

        private string GetUserName(User user) =>
            $"{user.Name} {user.Surname}";

        private string ConvertAddressToOneLine(Address address)
        {
            string result = $"{address.Street} {address.BuildingNumber}";

            if (address.ApartmentNumber != null)
                result += "/" + address.ApartmentNumber;

            result += $" {address.ZipCode} {address.City} {address.Country}";

            return result;
        }
    }
}
