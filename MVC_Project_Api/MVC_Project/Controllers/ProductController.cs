using Microsoft.AspNetCore.Mvc;
using MVC_Project.Logic.Products.Interfaces;
using MVC_Project.Logic.Requests;
using System.Threading.Tasks;

namespace MVC_Project.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProductController : ControllerBase
    {
        private readonly IProductService _productService;

        public ProductController(IProductService productService)
        {
            _productService = productService;
        }

        [HttpGet]
        public async Task<IActionResult> GetProductListAsync()
        {
            var result = await _productService.GetProductListAsync();

            return Ok(result.Response);
        }

        [HttpGet("by-id/{productId}")]
        public async Task<IActionResult> GetProductListAsync([FromRoute] int productId)
        {
            var result = await _productService.GetProductByIdAsync(productId);

            if (result.ErrorResponse == null)
            {
                return Ok(result.Response);
            }
            else
            {
                return StatusCode(result.ErrorResponse.ErrorCode, result.ErrorResponse);
            }
        }

        [HttpDelete("delete/{productId}")]
        public async Task<IActionResult> DeleteProductAsync([FromRoute] int productId)
        {
            var result = await _productService.DeleteProductAsync(productId);

            if (result.ErrorResponse == null)
            {
                return Ok(result.Response);
            }
            else
            {
                return StatusCode(result.ErrorResponse.ErrorCode, result.ErrorResponse);
            }
        }


        [HttpPost]
        public async Task<IActionResult> AddProductFrom([FromBody] AddProductRequest request)
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

        [HttpGet("bestsellers/{count}")]
        public async Task<IActionResult> GetBestsellersAsync([FromRoute] int count)
        {
            var result = await _productService.GetBestsellersAsync(count);

            return Ok(result.Response);
        }
    }
}
