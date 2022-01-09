using Microsoft.AspNetCore.Mvc;
using MVC_Project.Logic.Customer.Interfaces;
using MVC_Project.Logic.Customer.Requests;
using System.Threading.Tasks;

namespace MVC_Project.Api.Controllers.Customer
{
    [ApiController]
    [Route("customer/cart")]
    public class CustomerCartController : ControllerBase
    {
        private readonly ICartService _cartService;

        public CustomerCartController(ICartService cartService)
        {
            _cartService = cartService;
        }

        [HttpPost("change-product-count")]
        public async Task<IActionResult> ChangeProductCartCountAsync([FromBody] ChangeProductCartCountRequest request)
        {
            var result = await _cartService.ChangeProductCartCountAsync(request);

            if (result.ErrorResponse == null)
            {
                return Ok(result.Response);
            }

            return StatusCode(result.ErrorResponse.ErrorCode, result.ErrorResponse);
        }

        [HttpGet("user-cart")]
        public async Task<IActionResult> GetUserCartAsync()
        {
            var result = await _cartService.GetUserCartAsync();

            return Ok(result.Response);
        }

        [HttpPost("calculate/{cartId}")]
        public async Task<IActionResult> CalculateCartAsync([FromRoute] int cartId)
        {
            var result = await _cartService.CalculateAsync(cartId);

            if (result.ErrorResponse == null)
            {
                return Ok(result.Response);
            }

            return StatusCode(result.ErrorResponse.ErrorCode, result.ErrorResponse);
        }
    }
}
