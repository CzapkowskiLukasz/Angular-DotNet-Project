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
    public class AdminProductService : IAdminProductService
    {
        private readonly DataContext _dataContext;
        private readonly IMapper _mapper;

        public AdminProductService(DataContext dataContext, IMapper mapper)
        {
            _dataContext = dataContext;
            _mapper = mapper;
        }

        public async Task<HandleResult<AdminAddProductResponse>> AddProductAsync(AdminAddProductRequest request)
        {
            var result = new HandleResult<AdminAddProductResponse>();

            if (request == null)
            {
                result.ErrorResponse = new ErrorResponse("Wrong data", 400);
                return result;
            }

            var producer = await _dataContext.Producers.SingleOrDefaultAsync(x => x.ProducerId == request.ProducerId);
            var category = await _dataContext.Categories.SingleOrDefaultAsync(x => x.CategoryId == request.CategoryId);

            if (producer == null)
            {
                result.ErrorResponse = new ErrorResponse("Producer not found", 404);
                return result;
            }
            else if (category == null)
            {
                result.ErrorResponse = new ErrorResponse("Category not found", 404);
                return result;
            }

            var product = _mapper.Map<Product>(request);

            await _dataContext.Products.AddAsync(product);
            var added = await _dataContext.SaveChangesAsync();

            if (added != 1)
            {
                result.ErrorResponse = new ErrorResponse("Add error", 500);
                return result;
            }

            result.Response = new AdminAddProductResponse
            {
                ProductId = product.ProductId
            };

            return result;
        }

        public async Task<HandleResult<AdminGetProductListResponse>> GetProductListAsync()
        {
            var result = new HandleResult<AdminGetProductListResponse>();

            var products = await _dataContext.Products
                .Include(x => x.Producer).ToListAsync();

            result.Response = _mapper.Map<AdminGetProductListResponse>(products);

            return result;
        }

        public async Task<HandleResult<AdminUpdateProductResponse>> UpdateAsync(AdminUpdateProductRequest request)
        {
            var result = new HandleResult<AdminUpdateProductResponse>();

            if (request == null)
            {
                result.ErrorResponse = new ErrorResponse("Wrong data", 400);
                return result;
            }

            var product = await _dataContext.Products.SingleOrDefaultAsync(x => x.ProductId == request.ProductId);

            if (product == null)
            {
                result.ErrorResponse = new ErrorResponse("Product not found", 404);
                return result;
            }

            var producer = await _dataContext.Producers.SingleOrDefaultAsync(x => x.ProducerId == request.ProducerId);
            var category = await _dataContext.Categories.SingleOrDefaultAsync(x => x.CategoryId == request.CategoryId);

            if (producer == null)
            {
                result.ErrorResponse = new ErrorResponse("Producer not found", 404);
                return result;
            }
            else if (category == null)
            {
                result.ErrorResponse = new ErrorResponse("Category not found", 404);
                return result;
            }

            product = _mapper.Map<AdminUpdateProductRequest, Product>(request, product);

            var updated = await _dataContext.SaveChangesAsync();

            if (updated != 1)
            {
                result.ErrorResponse = new ErrorResponse("Update error", 500);
                return result;
            }

            result.Response = _mapper.Map<AdminUpdateProductResponse>(product);

            return result;
        }
    }
}
