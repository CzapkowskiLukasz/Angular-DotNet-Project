using AutoMapper;
using Microsoft.EntityFrameworkCore;
using MVC_Project.Domain;
using MVC_Project.Domain.Entities;
using MVC_Project.Logic.Products.Interfaces;
using MVC_Project.Logic.Requests;
using MVC_Project.Logic.Responses;
using System.Linq;
using System.Threading.Tasks;

namespace MVC_Project.Logic.Products.Services
{
    public class ProductService : IProductService
    {
        private readonly DataContext _dataContext;
        private readonly IMapper _mapper;

        public ProductService(DataContext dataContext, IMapper mapper)
        {
            _dataContext = dataContext;
            _mapper = mapper;
        }

        public async Task<HandleResult<GetProductListResponse>> GetProductListAsync()
        {
            var result = new HandleResult<GetProductListResponse>();

            var products = await _dataContext.Products
                .Include(x => x.Producer).ToListAsync();

            result.Response = _mapper.Map<GetProductListResponse>(products);

            return result;
        }

        public async Task<HandleResult<GetProductByIdResponse>> GetProductByIdAsync(int productId)
        {
            var result = new HandleResult<GetProductByIdResponse>();

            var product = await _dataContext.Products
                .Include(x => x.Category)
                .Include(x => x.Producer)
                .SingleOrDefaultAsync(x => x.ProductId == productId);

            if (product == null)
            {
                result.ErrorResponse = new ErrorResponse("Not found", 404);
            }
            else
            {
                result.Response = _mapper.Map<GetProductByIdResponse>(product);
            }

            return result;
        }

        public async Task<HandleResult<string>> DeleteProductAsync(int productId)
        {
            var result = new HandleResult<string>();
            var product = await _dataContext.Products.SingleOrDefaultAsync(x => x.ProductId == productId);

            if (product == null)
            {
                result.ErrorResponse = new ErrorResponse("Not found", 404);
                return result;
            }

            _dataContext.Products.Remove(product);
            var deleted = await _dataContext.SaveChangesAsync();

            if (deleted != 1)
            {
                result.ErrorResponse = new ErrorResponse("Delete error", 500);
                return result;
            }

            result.Response = "Success";
            return result;
        }

        public async Task<HandleResult<string>> AddProductAsync(AddProductRequest request)
        {
            var result = new HandleResult<string>();
            var product = _mapper.Map<Product>(request);

            await _dataContext.Products.AddAsync(product);
            var added = await _dataContext.SaveChangesAsync();

            if (added != 1)
            {
                result.ErrorResponse = new ErrorResponse("Add error", 500);
                return result;
            }

            result.Response = "Success";
            return result;
        }

        public async Task<HandleResult<GetBestsellersResponse>> GetBestsellersAsync(int count)
        {
            var result = new HandleResult<GetBestsellersResponse>();

            var products = await _dataContext.Products
                .Include(x => x.Producer).ToListAsync();

            var bestsellers = products.OrderByDescending(x => x.SoldCount).Take(count).ToList();

            result.Response = _mapper.Map<GetBestsellersResponse>(bestsellers);

            return result;
        }
    }
}
