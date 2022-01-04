using Microsoft.AspNetCore.Mvc;
using MVC_Project.Logic.Customer.Interfaces;
using MVC_Project.Logic.Customer.Requests;
using System.Threading.Tasks;

namespace MVC_Project.Api.Controllers.Customer
{
    [ApiController]
    [Route("customer")]
    public class CustomerProductController : ControllerBase
    {
        private readonly ICustomerProductService _productService;
        private readonly ICustomerAddressService _addressService;
        private readonly ICartService _cartService;

        public CustomerProductController(ICustomerProductService productService, ICustomerAddressService addressService, ICartService cartService)
        {
            _productService = productService;
            _addressService = addressService;
            _cartService = cartService;
        }

        [HttpGet("product/bestsellers/{count}")]
        public async Task<IActionResult> GetBestsellersAsync([FromRoute] int count)
        {
            var result = await _productService.GetBestsellersAsync(count);

            return Ok(result.Response);
        }

        [HttpGet("product/by-categoryId/{categoryId}")]
        public async Task<IActionResult> GetProductsByCategoryAsync([FromRoute] int categoryId)
        {
            var result = await _productService.GetProductsByCategoryAsync(categoryId);

            return Ok(result.Response);
        }

        [HttpGet("address/by-userId/{userId}")]
        public async Task<IActionResult> GetAddressesAsync([FromRoute] int userId)
        {
            var result = await _addressService.GetAddressesByUser(userId);

            return Ok(result.Response);
        }

        [HttpPost("cart/change-product-count")]
        public async Task<IActionResult> ChangeProductCartCountAsync([FromBody] ChangeProductCartCountRequest request)
        {
            var result = await _cartService.ChangeProductCartCountAsync(request);

            if (result.ErrorResponse == null)
            {
                return Ok(result.Response);
            }

            return StatusCode(result.ErrorResponse.ErrorCode, result.ErrorResponse);
        }

        [HttpGet("cart/user-cart")]
        public async Task<IActionResult> GetUserCartAsync()
        {
            var result = await _cartService.GetUserCartAsync();

            return Ok(result.Response);
        }
    }
}
