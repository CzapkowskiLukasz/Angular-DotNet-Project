using AutoMapper;
using Microsoft.EntityFrameworkCore;
using MVC_Project.Domain;
using MVC_Project.Logic.Interfaces;
using MVC_Project.Logic.Responses;
using System.Threading.Tasks;

namespace MVC_Project.Logic.Services
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


        public async Task<HandleResult<GetProductListResponse>> GetProductList()
        {
            var result = new HandleResult<GetProductListResponse>();

            var products = await _dataContext.Products.ToListAsync();

            result.Response = _mapper.Map<GetProductListResponse>(products);

            return result;
        }

        public async Task<HandleResult<GetProductByIdResponse>> GetProductById(int productId)
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
    }
}
