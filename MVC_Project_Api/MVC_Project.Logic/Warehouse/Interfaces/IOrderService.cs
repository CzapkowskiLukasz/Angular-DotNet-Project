using MVC_Project.Logic.Commons;
using MVC_Project.Logic.Warehouse.Responses;
using System.Threading.Tasks;

namespace MVC_Project.Logic.Warehouse.Interfaces
{
    public interface IOrderService
    {
        public Task<HandleResult<GetOrderListResponse>> GetOrderListAsync();

        public Task<HandleResult<GetOrderByIdResponse>> GetOrderByIdAsync(int orderId);

        public Task<HandleResult<GetOrderListResponse>> GetOrderByUserIdAsync(int userId);

        public Task<HandleResult<string>> DeleteOrderAsync(int orderId);
    }
}
