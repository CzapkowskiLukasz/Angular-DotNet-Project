﻿using AutoMapper;
using Microsoft.EntityFrameworkCore;
using MVC_Project.Domain;
using MVC_Project.Logic.Commons;
using MVC_Project.Logic.Global.Responses;
using MVC_Project.Logic.Warehouse.Interfaces;
using MVC_Project.Logic.Warehouse.Responses;
using System.Threading.Tasks;

namespace MVC_Project.Logic.Warehouse.Services
{
    public class OrderService : IOrderService
    {
        private readonly DataContext _dataContext;
        private readonly IMapper _mapper;

        public OrderService(DataContext dataContext, IMapper mapper)
        {
            _dataContext = dataContext;
            _mapper = mapper;
        }

        public async Task<HandleResult<GetOrderListResponse>> GetOrderListAsync()
        {
            var result = new HandleResult<GetOrderListResponse>();

            var orders = await _dataContext.Orders
                .Include(x => x.OrderStatus)
                .Include(x => x.User)
                .ToListAsync();

            result.Response = _mapper.Map<GetOrderListResponse>(orders);

            return result;
        }

        public async Task<HandleResult<GetOrderByIdResponse>> GetOrderByIdAsync(int orderId)
        {
            var result = new HandleResult<GetOrderByIdResponse>();

            var order = await _dataContext.Orders
                .Include(x => x.Address)
                .Include(x => x.OrderStatus)
                .Include(x => x.User)
                .SingleOrDefaultAsync(x => x.OrderId == orderId);

            if (order == null)
            {
                result.ErrorResponse = new ErrorResponse("Not found", 404);
            }
            else
            {
                result.Response = _mapper.Map<GetOrderByIdResponse>(order);
            }

            return result;
        }

        public async Task<HandleResult<string>> DeleteOrderAsync(int orderId)
        {
            var result = new HandleResult<string>();
            var order = await _dataContext.Orders.SingleOrDefaultAsync(x => x.OrderId == orderId);

            if (order == null)
            {
                result.ErrorResponse = new ErrorResponse("Not found", 404);
                return result;
            }

            _dataContext.Orders.Remove(order);
            var deleted = await _dataContext.SaveChangesAsync();

            if (deleted != 1)
            {
                result.ErrorResponse = new ErrorResponse("Delete error", 500);
                return result;
            }

            result.Response = "Success";
            return result;
        }
    }
}
