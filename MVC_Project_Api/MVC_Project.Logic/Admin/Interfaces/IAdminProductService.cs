using MVC_Project.Logic.Admin.Requests;
using MVC_Project.Logic.Admin.Responses;
using MVC_Project.Logic.Commons;
using System.Threading.Tasks;

namespace MVC_Project.Logic.Admin.Interfaces
{
    public interface IAdminProductService
    {
        public Task<HandleResult<AdminGetProductListResponse>> GetProductListAsync();

        public Task<HandleResult<AdminAddProductResponse>> AddProductAsync(AdminAddProductRequest request);

        public Task<HandleResult<AdminUpdateProductResponse>> UpdateAsync(AdminUpdateProductRequest request);

        public Task<HandleResult<AdminGetProductByIdResponse>> GetByIdAsync(int productId);

        public Task<HandleResult<bool>> DeleteAsync(int productId);
    }
}
