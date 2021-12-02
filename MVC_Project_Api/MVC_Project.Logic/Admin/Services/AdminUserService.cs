using AutoMapper;
using Microsoft.EntityFrameworkCore;
using MVC_Project.Domain;
using MVC_Project.Logic.Admin.Interfaces;
using MVC_Project.Logic.Admin.Responses;
using MVC_Project.Logic.Commons;
using System.Threading.Tasks;

namespace MVC_Project.Logic.Admin.Services
{
    public class AdminUserService : IAdminUserService
    {
        private readonly DataContext _dataContext;
        private readonly IMapper _mapper;

        public AdminUserService(DataContext dataContext, IMapper mapper)
        {
            _dataContext = dataContext;
            _mapper = mapper;
        }

        public async Task<HandleResult<AdminGetUserListResponse>> GetListAsync()
        {
            var result = new HandleResult<AdminGetUserListResponse>();

            var users = await _dataContext.Users.ToListAsync();

            result.Response = _mapper.Map<AdminGetUserListResponse>(users);

            return result;
        }
    }
}
