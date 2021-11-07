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
                .Include(x => x.OrderStatus).ToListAsync();

            result.Response = _mapper.Map<GetOrderListResponse>(orders);

            return result;
        }
    }
}
