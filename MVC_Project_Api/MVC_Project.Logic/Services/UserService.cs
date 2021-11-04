using MVC_Project.Domain;
using MVC_Project.Domain.Entities;
using MVC_Project.Logic.Interfaces;
using MVC_Project.Logic.Requests;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MVC_Project.Logic.Services
{
    public class UserService : IUserService
    {
        private readonly DataContext _dataContext;

        public UserService(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        public Task<bool> DeleteAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<List<User>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task<User> GetByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<string> LoginAsync(LoginRequest request)
        {
            throw new NotImplementedException();
        }

        public Task<string> RegisterAsync(RegisterRequest request)
        {
            throw new NotImplementedException();
        }

        public Task<User> UpdateAsync(int id, UpdateUserRequest request)
        {
            throw new NotImplementedException();
        }

        public Task<User> UpdatePasswordAsync(int id, string password)
        {
            throw new NotImplementedException();
        }

        public Task<User> UpdateRoleAsync(int id, string role)
        {
            throw new NotImplementedException();
        }
    }
}
