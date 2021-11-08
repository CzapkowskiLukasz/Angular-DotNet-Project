using MVC_Project.Logic.Responses;
using System.Threading.Tasks;

namespace MVC_Project.Logic.Interfaces
{
    public interface IOrderService
    {
        public Task<HandleResult<GetOrderListResponse>> GetOrderListAsync();
        
        public Task<HandleResult<GetOrderByIdResponse>> GetOrderByIdAsync(int orderId);

        public Task<HandleResult<string>> DeleteOrderAsync(int orderId);
    }
}
