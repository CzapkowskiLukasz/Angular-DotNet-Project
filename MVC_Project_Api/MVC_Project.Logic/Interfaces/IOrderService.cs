using MVC_Project.Logic.Responses;
using System.Threading.Tasks;

namespace MVC_Project.Logic.Interfaces
{
    public interface IOrderService
    {
        public Task<HandleResult<GetOrderListResponse>> GetOrderListAsync();
    }
}
