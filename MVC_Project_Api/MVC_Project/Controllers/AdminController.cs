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
        private readonly IAdminCategoryService _categoryService;
        private readonly IAdminDiscountService _discountService;
        private readonly IAdminProducerService _producerService;
        private readonly IAdminProductService _productService;
        private readonly IAdminUserService _userService;

        public AdminController(IAdminCategoryService categoryService, IAdminDiscountService discountService, IAdminProducerService producerService, IAdminProductService productService, IAdminUserService userService)
        {
            _categoryService = categoryService;
            _discountService = discountService;
            _producerService = producerService;
            _productService = productService;
            _userService = userService;
        }

        [HttpGet("product")]
        public async Task<IActionResult> GetProductsAsync()
        {
            var result = await _productService.GetProductListAsync();

            return Ok(result.Response);
        }

        [HttpPost("product")]
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

        [HttpGet("producers-dropdown")]
        public async Task<IActionResult> GetProducersDropdownListAsync()
        {
            var result = await _producerService.GetProducersListAsync();

            return Ok(result.Response);
        }

        [HttpGet("categories")]
        public async Task<IActionResult> GetCategoryListAsync()
        {
            var result = await _categoryService.GetListAsync();

            return Ok(result.Response);
        }

        [HttpGet("users")]
        public async Task<IActionResult> GetUserListAsync()
        {
            var result = await _userService.GetListAsync();

            return Ok(result.Response);
        }

        [HttpGet("discounts")]
        public async Task<IActionResult> GetDiscountListAsync()
        {
            var result = await _discountService.GetListAsync();

            return Ok(result.Response);
        }

        [HttpPost("producer-add")]
        public async Task<IActionResult> AddProducer([FromBody] AddProducerRequest request)
        {
            var result = await _producerService.AddAsync(request);

            if (result.ErrorResponse == null)
            {
                return Ok(result.Response);
            }

            return StatusCode(result.ErrorResponse.ErrorCode, result.ErrorResponse);
        }
    }
}