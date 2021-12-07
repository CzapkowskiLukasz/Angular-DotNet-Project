using AutoMapper;
using Microsoft.EntityFrameworkCore;
using MVC_Project.Domain;
using MVC_Project.Domain.Entities;
using MVC_Project.Logic.Admin.Interfaces;
using MVC_Project.Logic.Admin.Requests;
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

        public async Task<HandleResult<AddCategoryResponse>> AddAsync(AddCategoryRequest request)
        {
            var result = new HandleResult<AddCategoryResponse>();

            if (request == null)
            {
                result.ErrorResponse = new ErrorResponse("Bad request", 400);
                return result;
            }

            if (request.ParentId != 0)
            {
                var parent = await _dataContext.Categories
                  .SingleOrDefaultAsync(x => x.CategoryId == request.ParentId);

                if (parent == null)
                {
                    result.ErrorResponse = new ErrorResponse("Parent category not found", 404);
                    return result;
                }
            }

            var category = _mapper.Map<Category>(request);

            await _dataContext.Categories.AddAsync(category);
            var added = await _dataContext.SaveChangesAsync();

            if (added != 1)
            {
                result.ErrorResponse = new ErrorResponse("Add error", 500);
                return result;
            }

            result.Response = _mapper.Map<AddCategoryResponse>(category);
            return result;
        }

        public async Task<HandleResult<AdminGetCategoryByIdResponse>> GetByIdAsync(int categoryId)
        {
            var result = new HandleResult<AdminGetCategoryByIdResponse>();

            var category = await _dataContext.Categories.SingleOrDefaultAsync(x => x.CategoryId == categoryId);

            if (category == null)
            {
                result.ErrorResponse = new ErrorResponse("Category not found", 404);
            }
            else
            {
                result.Response = _mapper.Map<AdminGetCategoryByIdResponse>(category);
            }

            return result;
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

        public async Task<HandleResult<UpdateCategoryResponse>> UpdateAsync(UpdateCategoryRequest request)
        {
            var result = new HandleResult<UpdateCategoryResponse>();

            if (request == null)
            {
                result.ErrorResponse = new ErrorResponse("Bad request", 400);
                return result;
            }

            var category = await _dataContext.Categories.SingleOrDefaultAsync(x => x.CategoryId == request.CategoryId);

            if (category == null)
            {
                result.ErrorResponse = new ErrorResponse("Category not found", 404);
                return result;
            }

            if (request.ParentId != 0)
            {
                var parent = await _dataContext.Categories
                  .SingleOrDefaultAsync(x => x.CategoryId == request.ParentId);

                if (parent == null)
                {
                    result.ErrorResponse = new ErrorResponse("Parent category not found", 404);
                    return result;
                }
            }

            category = _mapper.Map<UpdateCategoryRequest, Category>(request, category);

            var updated = await _dataContext.SaveChangesAsync();

            if (updated != 1)
            {
                result.ErrorResponse = new ErrorResponse("Update error", 500);
                return result;
            }

            result.Response = _mapper.Map<UpdateCategoryResponse>(category);
            return result;
        }
    }
}
