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
        private readonly IAdminProducerService _producerService;

        public AdminController(IAdminProductService productService, IAdminProducerService producerService)
        {
            _productService = productService;
            _producerService = producerService;
        }

        [HttpGet("products")]
        public async Task<IActionResult> GetProductsAsync()
        {
            var result = await _productService.GetProductListAsync();

            return Ok(result.Response);
        }

        [HttpPost("add-product")]
        public async Task<IActionResult> AddProductAsync([FromBody] AdminAddProductRequest request)
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

        [HttpGet("producers")]
        public async Task<IActionResult> GetProducersListAsync()
        {
            var result = await _producerService.GetProducersListAsync();

            return Ok(result.Response);
        }
    }
}
