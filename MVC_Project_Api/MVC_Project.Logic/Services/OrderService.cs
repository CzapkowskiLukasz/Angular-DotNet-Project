using AutoMapper;
using Microsoft.EntityFrameworkCore;
using MVC_Project.Domain;
using MVC_Project.Logic.Interfaces;
using MVC_Project.Logic.Responses;
using System.Threading.Tasks;

namespace MVC_Project.Logic.Services
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
    }
}
