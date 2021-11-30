using MVC_Project.Domain.Entities;
using MVC_Project.Logic.Commons;
using MVC_Project.Logic.Global.Requests;
using MVC_Project.Logic.Global.Responses;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MVC_Project.Logic.Global.Interfaces
{
    public interface IUserService
    {
        public Task<bool> DeleteAsync(int id);

        public Task<User> GetByIdAsync(int id);

        public Task<List<User>> GetAllAsync();

        public Task<HandleResult<AuthenticationResponse>> LoginAsync(LoginRequest request);

        public Task<HandleResult<AuthenticationResponse>> RegisterAsync(RegisterRequest request);

        public Task<User> UpdateAsync(int id, UpdateUserRequest request);

        public Task<HandleResult<string>> ChangePasswordAsync(ChangePasswordRequest request);

        public Task<User> UpdateRoleAsync(int id, string role);
    }
}
