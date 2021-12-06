using AutoMapper;
using Microsoft.EntityFrameworkCore;
using MVC_Project.Domain;
using MVC_Project.Logic.Admin.Interfaces;
using MVC_Project.Logic.Admin.Responses;
using MVC_Project.Logic.Commons;
using System.Threading.Tasks;

namespace MVC_Project.Logic.Admin.Services
{
    public class AdminCategoryService : IAdminCategoryService
    {
        private readonly DataContext _dataContext;
        private readonly IMapper _mapper;

        public AdminCategoryService(DataContext dataContext, IMapper mapper)
        {
            _dataContext = dataContext;
            _mapper = mapper;
        }

        public async Task<HandleResult<AdminGetCategoryDropdownListResponse>> GetDropdownListAsync()
        {
            var result = new HandleResult<AdminGetCategoryDropdownListResponse>();

            var categories = await _dataContext.Categories.ToListAsync();

            result.Response = _mapper.Map<AdminGetCategoryDropdownListResponse>(categories);

            return result;
        }

        public async Task<HandleResult<AdminGetCategoryListResponse>> GetListAsync()
        {
            var result = new HandleResult<AdminGetCategoryListResponse>();

            var categories = await _dataContext.Categories
                .Include(x => x.ParentCategory).ToListAsync();

            result.Response = _mapper.Map<AdminGetCategoryListResponse>(categories);

            return result;
        }
    }
}
