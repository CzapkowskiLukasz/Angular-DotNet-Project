using MVC_Project.Logic.Commons;
using MVC_Project.Logic.Warehouse.Requests;
using MVC_Project.Logic.Warehouse.Responses;
using System.Threading.Tasks;

namespace MVC_Project.Logic.Warehouse.Interfaces
{
    public interface IProductService
    {
        public Task<HandleResult<GetProductListResponse>> GetProductListAsync();

        public Task<HandleResult<GetProductByIdResponse>> GetProductByIdAsync(int productId);

        public Task<HandleResult<string>> DeleteProductAsync(int productId);

        public Task<HandleResult<string>> AddProductAsync(AddProductRequest request);

        public Task<HandleResult<GetProductListByOrderResponse>> GetListByOrder(int orderId);

        public Task<HandleResult<string>> UpdateProductAsync(UpdateProductRequest request);
    }
}
