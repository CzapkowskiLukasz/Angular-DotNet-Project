using Microsoft.AspNetCore.Mvc;
using MVC_Project.Logic.Customer.Interfaces;
using System.Threading.Tasks;

namespace MVC_Project.Api.Controllers.Customer
{
    [ApiController]
    [Route("customer/product")]
    public class CustomerProductController : ControllerBase
    {
        private readonly ICustomerProductService _productService;

        public CustomerProductController(ICustomerProductService productService)
        {
            _productService = productService;
        }

        [HttpGet("bestsellers/{count}")]
        public async Task<IActionResult> GetBestsellersAsync([FromRoute] int count)
        {
            var result = await _productService.GetBestsellersAsync(count);

            return Ok(result.Response);
        }
    }
}
