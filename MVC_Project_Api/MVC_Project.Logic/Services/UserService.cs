using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using MVC_Project.Domain;
using MVC_Project.Domain.Entities;
using MVC_Project.Logic.Commons;
using MVC_Project.Logic.Interfaces;
using MVC_Project.Logic.Requests;
using MVC_Project.Logic.Responses;
using MVC_Project.Logic.Settings;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MVC_Project.Logic.Services
{
    public class UserService : IUserService
    {
        private readonly DataContext _dataContext;
        private readonly JwtSettings _jwtSettings;
        private readonly UserManager<User> _userManager;
        private readonly HttpContext _httpContext;

        public UserService(DataContext dataContext, JwtSettings jwtSettings, UserManager<User> userManager, IHttpContextAccessor httpContextAccessor)
        {
            _dataContext = dataContext;
            _jwtSettings = jwtSettings;
            _userManager = userManager;
            _httpContext = httpContextAccessor.HttpContext;
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

        public async Task<HandleResult<AuthenticationResponse>> LoginAsync(LoginRequest request)
        {
            var result = new HandleResult<AuthenticationResponse>();

            var user = await _userManager.FindByEmailAsync(request.Email);
            bool error = user == null;

            if (!error)
                error = !await _userManager.CheckPasswordAsync(user, request.Password);

            if (error)
            {
                result.ErrorResponse = new ErrorResponse("Wrong email or password.", 404);
            }
            else
            {
                result.Response = GenerateAuthenticationResponse(user);
            }

            return result;
        }

        public async Task<HandleResult<AuthenticationResponse>> RegisterAsync(RegisterRequest request)
        {
            var result = new HandleResult<AuthenticationResponse>();

            var existingUser = await _userManager.FindByEmailAsync(request.Email);
            if (existingUser != null)
                throw new Exception($"Email {request.Email} is already used.");

            var user = new User
            {
                Name = request.Name,
                Surname = request.Surname,
                Email = request.Email,
                UserName = request.Email,
                PasswordHash = request.Password
            };

            var createdUser = await _userManager.CreateAsync(user, request.Password);
            if (!createdUser.Succeeded)
                result.ErrorResponse = new ErrorResponse("Register error", 404);

            result.Response = GenerateAuthenticationResponse(user);

            return result;
        }

        public Task<User> UpdateAsync(int id, UpdateUserRequest request)
        {
            throw new NotImplementedException();
        }

        public async Task<HandleResult<string>> ChangePasswordAsync(ChangePasswordRequest request)
        {
            var result = new HandleResult<string>();

            // Get logged user because only logged user can change own password
            var loggedInUserEmail = _userManager.GetUserId(_httpContext.User);
            var loggedUser = await _userManager.FindByEmailAsync(loggedInUserEmail);

            if (loggedUser == null)
            {
                result.ErrorResponse = new ErrorResponse("Not found", 404);
                return result;
            }

            var passwordChanged = await _userManager.ChangePasswordAsync(loggedUser, request.OldPassword, request.NewPassword);

            if (!passwordChanged.Succeeded)
                result.ErrorResponse = new ErrorResponse("Change password error", 500);

            result.Response = "Success";
            return result;
        }

        public Task<User> UpdateRoleAsync(int id, string role)
        {
            throw new NotImplementedException();
        }

        private AuthenticationResponse GenerateAuthenticationResponse(User user)
        {
            var tokenGenerator = new TokenGenerator(_jwtSettings);

            var response = new AuthenticationResponse
            {
                Token = tokenGenerator.GenerateToken(user)
            };

            return response;
        }
    }
}
