using MVC_Project.Logic.Responses;
using System.Threading.Tasks;

namespace MVC_Project.Logic.Interfaces
{
    public interface IProductService
    {
        public Task<HandleResult<GetProductListResponse>> GetProductList();

        public Task<HandleResult<GetProductByIdResponse>> GetProductById(int productId);
    }
}
