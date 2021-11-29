using MVC_Project.Logic.Products.Responses;
using MVC_Project.Logic.Responses;
using System.Threading.Tasks;

namespace MVC_Project.Logic.Products.Interfaces
{
    public interface IAdminProductService
    {
        public Task<HandleResult<AdminGetProductListResponse>> GetProductListAsync();
    }
}
