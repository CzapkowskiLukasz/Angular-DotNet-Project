using Microsoft.AspNetCore.Mvc;
using MVC_Project.Logic.Admin.Interfaces;
using MVC_Project.Logic.Admin.Requests;
using System.Threading.Tasks;

namespace MVC_Project.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AdminController : ControllerBase
    {
        private readonly IAdminProductService _productService;

        public AdminController(IAdminProductService productService)
        {
            _productService = productService;
        }

        [HttpGet("products")]
        public async Task<IActionResult> GetProductsAsync()
        {
            var result = await _productService.GetProductListAsync();

            return Ok(result.Response);
        }

        [HttpPost("add-product")]
        public async Task<IActionResult> AddProduct([FromBody] AdminAddProductRequest request)
        {
            var result = await _productService.AddProductAsync(request);

            if (result.ErrorResponse == null)
            {
                return Ok(result.Response);
            }
            else
            {
                return StatusCode(result.ErrorResponse.ErrorCode, result.ErrorResponse);
            }
        }
    }
}
