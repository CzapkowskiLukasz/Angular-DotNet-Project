using MVC_Project.Logic.Admin.Responses;
using MVC_Project.Logic.Commons;
using System.Threading.Tasks;

namespace MVC_Project.Logic.Admin.Interfaces
{
    public interface IAdminCategoryService
    {
        public Task<HandleResult<AdminGetCategoryDropdownListResponse>> GetDropdownListAsync();

        public Task<HandleResult<AdminGetCategoryListResponse>> GetListAsync();
    }
}
