using MVC_Project.Logic.Commons;
using MVC_Project.Logic.Customer.Responses;
using System.Threading.Tasks;

namespace MVC_Project.Logic.Customer.Interfaces
{
    public interface ICustomerProductService
    {
        public Task<HandleResult<GetBestsellersResponse>> GetBestsellersAsync(int count);

        public Task<HandleResult<GetProductsResponse>> GetProductsByCategoryAsync(int categoryId);
    }
}
