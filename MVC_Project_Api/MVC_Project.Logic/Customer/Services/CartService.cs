using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using MVC_Project.Domain;
using MVC_Project.Domain.Entities;
using MVC_Project.Logic.Commons;
using MVC_Project.Logic.Customer.Interfaces;
using MVC_Project.Logic.Customer.Requests;
using MVC_Project.Logic.Customer.Responses;
using System.Linq;
using System.Threading.Tasks;

namespace MVC_Project.Logic.Customer.Services
{
    public class CartService : ICartService
    {
        private readonly DataContext _dataContext;
        private readonly IMapper _mapper;
        private readonly HttpContext _httpContext;
        private readonly UserManager<User> _userManager;

        private User _user;
        private Product _product;
        private Cart _cart;
        private CartProduct _cartProduct;
        private ErrorResponse _errorResponse;

        public CartService(DataContext dataContext, IMapper mapper, IHttpContextAccessor httpContextAccessor, UserManager<User> userManager)
        {
            _dataContext = dataContext;
            _mapper = mapper;
            _httpContext = httpContextAccessor.HttpContext;
            _userManager = userManager;
        }

        public async Task<HandleResult<AddProductToCartResponse>> AddProductToCartAsync(AddProductToCartRequest request)
        {
            var result = new HandleResult<AddProductToCartResponse>();


            if (!CheckRequest(request)
                || !await GetLoggedUser()
                || !await GetProductAsync(request)
                || !await GetCartAsync())
            {
                result.ErrorResponse = _errorResponse;
                return result;
            }

            await GetCartProductAsync();


            if (!await TryChangeProductCartCount(request))
            {
                result.ErrorResponse = _errorResponse;
                return result;
            }

            result.Response = new AddProductToCartResponse
            {
                Result = true
            };
            return result;
        }



        public async Task<HandleResult<ChangeProductCartCountResponse>> ChangeProductCartCountAsync(ChangeProductCartCountRequest request)
        {
            var result = new HandleResult<ChangeProductCartCountResponse>();

            var loggedInUserEmail = _userManager.GetUserId(_httpContext.User);
            var user = await _userManager.FindByEmailAsync(loggedInUserEmail);

            if (user == null)
            {
                result.ErrorResponse = new ErrorResponse("User not found", 404);
                return result;
            }

            var product = await _dataContext.Products.SingleOrDefaultAsync(x => x.ProductId == request.ProductId);

            if (product == null)
            {
                result.ErrorResponse = new ErrorResponse("Product not found", 404);
                return result;
            }

            if (product.WarehouseQuantity < request.Count)
            {
                result.ErrorResponse = new ErrorResponse("Product has insufficient quantity in warehouse", 400);
                return result;
            }

            var cart = await _dataContext.Carts.SingleOrDefaultAsync(x => x.CartId == user.TemporaryCartId);

            if (cart == null)
            {
                if (request.Count == 0)
                {
                    result.ErrorResponse = new ErrorResponse("You cannot add 0 products to new cart", 400);
                    return result;
                }

                cart = new Cart();
                await _dataContext.Carts.AddAsync(cart);
                var added = await _dataContext.SaveChangesAsync();
                if (added != 1)
                {
                    result.ErrorResponse = new ErrorResponse("Error occured while adding new cart", 500);
                    return result;
                }

                user.TemporaryCartId = cart.CartId;
                var updated = await _dataContext.SaveChangesAsync();
                if (updated != 1)
                {
                    result.ErrorResponse = new ErrorResponse("Assign new temporary cart error", 500);
                    return result;
                }
            }

            var cartProduct = await _dataContext.CartProducts.SingleOrDefaultAsync(x =>
                x.ProductId == product.ProductId && x.CartId == cart.CartId);

            if (cartProduct == null && request.Count == 0)
            {
                result.ErrorResponse = new ErrorResponse("You cannot add 0 products to cart", 400);
                return result;
            }
            else if (cartProduct != null && request.Count == 0)
            {
                _dataContext.CartProducts.Remove(cartProduct);
            }
            else
            {
                if (cartProduct == null)
                {
                    cartProduct = new CartProduct
                    {
                        CartId = cart.CartId,
                        ProductId = product.ProductId
                    };
                    await _dataContext.CartProducts.AddAsync(cartProduct);
                }

                cartProduct.Quantity = request.Count;
                cartProduct.Price = cartProduct.Quantity * product.Price;
            }

            var changed = await _dataContext.SaveChangesAsync();

            if (changed == 1)
            {
                result.Response = new ChangeProductCartCountResponse
                {
                    Result = true
                };
            }
            else
            {
                result.ErrorResponse = new ErrorResponse("Change product count error", 500);
            }

            return result;
        }

        public async Task<HandleResult<GetUserCartResponse>> GetUserCartAsync()
        {
            var result = new HandleResult<GetUserCartResponse>();

            var loggedInUserEmail = _userManager.GetUserId(_httpContext.User);
            var user = await _userManager.FindByEmailAsync(loggedInUserEmail);

            if (user == null)
            {
                result.ErrorResponse = new ErrorResponse("User not found", 404);
                return result;
            }

            var cart = await _dataContext.Carts
                .Include(x => x.CartProducts)
                .ThenInclude(x => x.Product)
                .SingleOrDefaultAsync(x => x.CartId == user.TemporaryCartId);

            if (cart == null)
            {
                result.ErrorResponse = new ErrorResponse("Cart not found", 404);
                return result;
            }

            var products = cart.CartProducts.ToList();
            result.Response = _mapper.Map<GetUserCartResponse>(products, opt =>
                opt.Items["Sum"] = cart.Sum);
            return result;
        }

        private bool CheckRequest(AddProductToCartRequest request)
        {
            if (request.ProductId <= 0 || request.Count <= 0)
            {
                _errorResponse = new ErrorResponse("Bad request", 400);
                return false;
            }

            return true;
        }

        private async Task<bool> GetLoggedUser()
        {
            var loggedInUserEmail = _userManager.GetUserId(_httpContext.User);
            if (loggedInUserEmail != null)
            {
                _user = await _userManager.FindByEmailAsync(loggedInUserEmail);
            }

            if (_user == null)
            {
                _errorResponse = new ErrorResponse("User not found", 404);
                return false;
            }

            return true;
        }

        private async Task<bool> GetProductAsync(AddProductToCartRequest request)
        {
            _product = await _dataContext.Products.SingleOrDefaultAsync(x => x.ProductId == request.ProductId);

            if (_product == null)
            {
                _errorResponse = new ErrorResponse("Product not found", 404);
            }
            else if (_product.WarehouseQuantity < request.Count)
            {
                _errorResponse = new ErrorResponse("Product has insufficient quantity in warehouse", 400);
            }

            return _errorResponse == null;
        }

        private async Task<bool> GetCartAsync()
        {
            _cart = await _dataContext.Carts
                .Include(x => x.CartProducts)
                .SingleOrDefaultAsync(x => x.CartId == _user.TemporaryCartId);

            if (_cart == null)
            {
                _cart = new Cart();

                await _dataContext.Carts.AddAsync(_cart);

                var added = await _dataContext.SaveChangesAsync();

                if (added != 1)
                {
                    _errorResponse = new ErrorResponse("Error occured while adding the new cart", 500);
                }


                _user.TemporaryCartId = _cart.CartId;

                var updated = await _dataContext.SaveChangesAsync();

                if (updated != 1)
                {
                    _errorResponse = new ErrorResponse("Assign new temporary cart error", 500);
                }
            }

            return _errorResponse == null;
        }

        private async Task GetCartProductAsync()
        {
            _cartProduct = _cart.CartProducts.SingleOrDefault(x =>
                x.ProductId == _product.ProductId);

            if (_cartProduct == null)
            {
                _cartProduct = new CartProduct
                {
                    CartId = _cart.CartId,
                    ProductId = _product.ProductId,
                    Quantity = 0,
                    Price = 0
                };

                await _dataContext.CartProducts.AddAsync(_cartProduct);
            }
        }

        private async Task<bool> TryChangeProductCartCount(AddProductToCartRequest request)
        {
            _cartProduct.Quantity += request.Count;

            if (_cartProduct.Quantity > _product.WarehouseQuantity)
            {
                _errorResponse = new ErrorResponse("Too few products in warehouse", 400);
                return false;
            }

            _cartProduct.Price = _product.Price * _cartProduct.Quantity;

            var changes = await _dataContext.SaveChangesAsync();

            if (changes != 1)
            {
                _errorResponse = new ErrorResponse("Change cart count error", 500);
                return false;
            }

            return true;
        }

        public async Task<HandleResult<bool>> CalculateAsync(int cartId)
        {
            var result = new HandleResult<bool>();

            _cart = await _dataContext.Carts.Include(x => x.CartProducts)
                .SingleOrDefaultAsync(x => x.CartId == cartId);

            if (_cart == null)
            {
                result.ErrorResponse = new ErrorResponse("Not found cart", 404);
                return result;
            }

            decimal sum = 0;

            foreach (var item in _cart.CartProducts)
            {
                sum += item.Price.Value;
            }

            _cart.Sum = sum;

            int updated = await _dataContext.SaveChangesAsync();

            if (updated != 1)
            {
                result.ErrorResponse = new ErrorResponse("Cart calculating error", 500);
            }
            else
            {
                result.Response = true;
            }

            return result;
        }
    }
}
