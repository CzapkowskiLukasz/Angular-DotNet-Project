using MVC_Project.Domain.Entities;
using MVC_Project.Logic.Requests;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MVC_Project.Logic.Interfaces
{
    public interface IUserService
    {
        public Task<bool> DeleteAsync(int id);

        public Task<User> GetByIdAsync(int id);

        public Task<List<User>> GetAllAsync();

        public Task<string> LoginAsync(LoginRequest request);

        public Task<string> RegisterAsync(RegisterRequest request);

        public Task<User> UpdateAsync(int id, UpdateUserRequest request);

        public Task<string> ChangePasswordAsync(ChangePasswordRequest request);

        public Task<User> UpdateRoleAsync(int id, string role);
    }
}
