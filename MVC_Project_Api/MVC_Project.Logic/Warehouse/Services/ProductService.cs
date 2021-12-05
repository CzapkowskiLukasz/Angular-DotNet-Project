using AutoMapper;
using Microsoft.EntityFrameworkCore;
using MVC_Project.Domain;
using MVC_Project.Domain.Entities;
using MVC_Project.Logic.Commons;
using MVC_Project.Logic.Warehouse.Interfaces;
using MVC_Project.Logic.Warehouse.Requests;
using MVC_Project.Logic.Warehouse.Responses;
using System.Threading.Tasks;

namespace MVC_Project.Logic.Warehouse.Services
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
            if (request == null)
            {
                result.ErrorResponse = new ErrorResponse("Bad request", 400);
                return result;
            }

            var producer = await _dataContext.Producers.SingleOrDefaultAsync(x => x.Name == "AddedFromWarehouse");
            if (producer == null)
            {
                result.ErrorResponse = new ErrorResponse("Producer not found", 404);
                return result;
            }

            var category = await _dataContext.Categories.SingleOrDefaultAsync(x => x.Name == "AddedFromWarehouse");
            if (category == null)
            {
                result.ErrorResponse = new ErrorResponse("Category not found", 404);
                return result;
            }

            var product = _mapper.Map<Product>(request, opt =>
            {
                opt.Items["producerId"] = producer.ProducerId;
                opt.Items["categoryId"] = category.CategoryId;
            });

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

        public async Task<HandleResult<GetProductListByOrderResponse>> GetListByOrder(int orderId)
        {
            var result = new HandleResult<GetProductListByOrderResponse>();

            var order = await _dataContext.Orders.SingleOrDefaultAsync(x => x.OrderId == orderId);

            if (order == null)
            {
                result.ErrorResponse = new ErrorResponse("Order not found", 404);
                return result;
            }

            var cart = await _dataContext.Carts.Include(x => x.CartProducts)
                .ThenInclude(x => x.Product)
                .SingleOrDefaultAsync(x => x.CartId == order.CartId);

            if (cart == null)
            {
                result.ErrorResponse = new ErrorResponse("Cart not found", 404);
                return result;
            }

            var products = _mapper.Map<GetProductListByOrderResponse>(cart);

            result.Response = products;
            return result;
        }

        public async Task<HandleResult<string>> UpdateProductAsync(UpdateProductRequest request)
        {
            var result = new HandleResult<string>();

            if (request == null)
            {
                result.ErrorResponse = new ErrorResponse("Bad request", 400);
                return result;
            }

            var product = await _dataContext.Products.SingleOrDefaultAsync(x => x.ProductId == request.ProductId);

            if (product == null)
            {
                result.ErrorResponse = new ErrorResponse("Product not found", 404);
                return result;
            }

            product = _mapper.Map<UpdateProductRequest, Product>(request, product);

            var updated = await _dataContext.SaveChangesAsync();

            if (updated != 1)
            {
                result.ErrorResponse = new ErrorResponse("Update error", 500);
            }
            else
            {
                result.Response = "Success";
            }

            return result;
        }
    }
}
