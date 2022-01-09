using MVC_Project.Logic.Commons;
using MVC_Project.Logic.Customer.Requests;
using MVC_Project.Logic.Customer.Responses;
using System.Threading.Tasks;

namespace MVC_Project.Logic.Customer.Interfaces
{
    public interface ICartService
    {
        public Task<HandleResult<AddProductToCartResponse>> AddProductToCartAsync(AddProductToCartRequest request);

        public Task<HandleResult<ChangeProductCartCountResponse>> ChangeProductCartCountAsync(ChangeProductCartCountRequest request);

        public Task<HandleResult<GetUserCartResponse>> GetUserCartAsync();

        public Task<HandleResult<bool>> CalculateAsync(int cartId);
    }
}
