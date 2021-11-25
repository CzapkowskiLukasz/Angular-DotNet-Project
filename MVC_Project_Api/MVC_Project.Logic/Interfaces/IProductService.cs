using MVC_Project.Logic.Requests;
using MVC_Project.Logic.Responses;
using System.Threading.Tasks;

namespace MVC_Project.Logic.Interfaces
{
    public interface IProductService
    {
        public Task<HandleResult<GetProductListResponse>> GetProductListAsync();

        public Task<HandleResult<GetProductByIdResponse>> GetProductByIdAsync(int productId);

        public Task<HandleResult<string>> DeleteProductAsync(int productId);

        public Task<HandleResult<string>> AddProductAsync(AddProductRequest request);

        public Task<HandleResult<GetBestsellersResponse>> GetBestsellersAsync(int count);
    }
}
