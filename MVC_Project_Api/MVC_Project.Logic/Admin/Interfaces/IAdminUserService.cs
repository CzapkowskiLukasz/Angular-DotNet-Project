using MVC_Project.Logic.Admin.Responses;
using MVC_Project.Logic.Commons;
using System.Threading.Tasks;

namespace MVC_Project.Logic.Admin.Interfaces
{
    public interface IAdminUserService
    {
        public Task<HandleResult<AdminGetUserListResponse>> GetListAsync();
        public Task<HandleResult<AdminGetUserById>> GetUserByIdAsync(int id);

    }
}
