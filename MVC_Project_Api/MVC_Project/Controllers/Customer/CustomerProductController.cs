using Microsoft.AspNetCore.Mvc;
using MVC_Project.Logic.Customer.Interfaces;
using System.Threading.Tasks;

namespace MVC_Project.Api.Controllers.Customer
{
    [ApiController]
    [Route("customer")]
    public class CustomerProductController : ControllerBase
    {
        private readonly ICustomerProductService _productService;
        private readonly ICustomerAddressService _addressService;

        public CustomerProductController(ICustomerProductService productService, ICustomerAddressService addressService)
        {
            _productService = productService;
            _addressService = addressService;
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
    }
}
