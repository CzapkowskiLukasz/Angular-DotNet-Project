using Microsoft.AspNetCore.Mvc;
using MVC_Project.Logic.Interfaces;
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
        public async Task<IActionResult> GetProductList()
        {
            var result = await _productService.GetProductList();

            return Ok(result.Response);
        }
    }
}
