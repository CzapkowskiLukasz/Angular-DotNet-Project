using MVC_Project.Logic.Admin.Requests;
using MVC_Project.Logic.Admin.Responses;
using MVC_Project.Logic.Commons;
using System.Threading.Tasks;

namespace MVC_Project.Logic.Admin.Interfaces
{
    public interface IAdminCategoryService
    {
        public Task<HandleResult<AdminGetCategoryDropdownListResponse>> GetDropdownListAsync();

        public Task<HandleResult<AdminGetCategoryListResponse>> GetListAsync();

        public Task<HandleResult<AddCategoryResponse>> AddAsync(AddCategoryRequest request);

        public Task<HandleResult<AdminGetCategoryByIdResponse>> GetByIdAsync(int categoryId);

        public Task<HandleResult<UpdateCategoryResponse>> UpdateAsync(UpdateCategoryRequest request);

        public Task<HandleResult<bool>> DeleteAsync(int categoryId);
    }
}
