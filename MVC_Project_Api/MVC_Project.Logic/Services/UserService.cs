using Microsoft.AspNet.Identity;
using Microsoft.EntityFrameworkCore;
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

        public async Task<string> LoginAsync(LoginRequest request)
        {
            var user = await _dataContext.Users.FirstOrDefaultAsync(u => u.Email == request.Email);
            bool error = user == null;

            var hasher = new PasswordHasher();

            if (!error)
            {
                var verificationResult = hasher.VerifyHashedPassword(user.PasswordHash, request.Password);
                error = verificationResult != PasswordVerificationResult.Success;
            }

            if (error)
                throw new Exception("Wrong email or password.");

            return "Success";
        }

        public async Task<string> RegisterAsync(RegisterRequest request)
        {
            var existingUser = await _dataContext.Users.FirstOrDefaultAsync(u => u.Email == request.Email);
            if (existingUser != null)
                throw new Exception($"Email {request.Email} is already used.");

            request.Password = HashPassword(request.Password);

            var user = new User
            {
                Name = request.Name,
                Surname = request.Surname,
                Email = request.Email,
                PasswordHash = request.Password
            };

            await _dataContext.Users.AddAsync(user);
            await _dataContext.SaveChangesAsync();

            return "Success";
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


        private string HashPassword(string password)
        {
            var hasher = new PasswordHasher();
            string hashedPassword = hasher.HashPassword(password);
            return hashedPassword;
        }
    }
}
