﻿using Microsoft.AspNetCore.Mvc;
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
        private readonly IAdminCountryService _countryService;
        private readonly IAdminDiscountService _discountService;
        private readonly IAdminProducerService _producerService;
        private readonly IAdminProductService _productService;
        private readonly IAdminUserService _userService;

        public AdminController(IAdminCategoryService categoryService, IAdminCountryService countryService, IAdminDiscountService discountService, IAdminProducerService producerService, IAdminProductService productService, IAdminUserService userService)
        {
            _categoryService = categoryService;
            _countryService = countryService;
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

        [HttpGet("product/by-id/{productId}")]
        public async Task<IActionResult> GetProductByIdAsync([FromRoute] int productId)
        {
            var result = await _productService.GetByIdAsync(productId);

            if (result.ErrorResponse == null)
            {
                return Ok(result.Response);
            }

            return StatusCode(result.ErrorResponse.ErrorCode, result.ErrorResponse);
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

        [HttpPut("product")]
        public async Task<IActionResult> UpdateProductAsync([FromBody] AdminUpdateProductRequest request)
        {
            var result = await _productService.UpdateAsync(request);

            if (result.ErrorResponse == null)
            {
                return Ok(result.Response);
            }
            else
            {
                return StatusCode(result.ErrorResponse.ErrorCode, result.ErrorResponse);
            }
        }

        [HttpGet("producer")]
        public async Task<IActionResult> GetProducersListAsync()
        {
            var result = await _producerService.GetProducersListAsync();

            return Ok(result.Response);
        }

        [HttpGet("producer/dropdown")]
        public async Task<IActionResult> GetProducersDropdownListAsync()
        {
            var result = await _producerService.GetProducersListAsync();

            return Ok(result.Response);
        }

        [HttpPost("producer")]
        public async Task<IActionResult> AddProducer([FromBody] AddProducerRequest request)
        {
            var result = await _producerService.AddAsync(request);

            if (result.ErrorResponse == null)
            {
                return Ok(result.Response);
            }

            return StatusCode(result.ErrorResponse.ErrorCode, result.ErrorResponse);
        }

        [HttpPut("producer")]
        public async Task<IActionResult> UpdateProducerAsync([FromBody] UpdateProducerRequest request)
        {
            var result = await _producerService.UpdateAsync(request);

            if (result.ErrorResponse == null)
            {
                return Ok(result.Response);
            }

            return StatusCode(result.ErrorResponse.ErrorCode, result.ErrorResponse);
        }

        [HttpDelete("producer/{producerId}")]
        public async Task<IActionResult> DeleteProducerAsync([FromRoute] int producerId)
        {
            var result = await _producerService.DeleteAsync(producerId);

            if (result.ErrorResponse == null)
            {
                return Ok(result.Response);
            }

            return StatusCode(result.ErrorResponse.ErrorCode, result.ErrorResponse);
        }

        [HttpGet("category")]
        public async Task<IActionResult> GetCategoryListAsync()
        {
            var result = await _categoryService.GetListAsync();

            return Ok(result.Response);
        }

        [HttpGet("category/dropdown")]
        public async Task<IActionResult> GetCategoryDropdownListAsync()
        {
            var result = await _categoryService.GetDropdownListAsync();

            return Ok(result.Response);
        }

        [HttpGet("category/by-id/{categoryId}")]
        public async Task<IActionResult> GetCategoryByIdAsync([FromRoute] int categoryId)
        {
            var result = await _categoryService.GetByIdAsync(categoryId);

            if (result.ErrorResponse == null)
            {
                return Ok(result.Response);
            }

            return StatusCode(result.ErrorResponse.ErrorCode, result.ErrorResponse);
        }

        [HttpPost("category")]
        public async Task<IActionResult> AddCategoryAsync([FromBody] AddCategoryRequest request)
        {
            var result = await _categoryService.AddAsync(request);

            if (result.ErrorResponse == null)
            {
                return Ok(result.Response);
            }

            return StatusCode(result.ErrorResponse.ErrorCode, result.ErrorResponse);
        }

        [HttpPut("category")]
        public async Task<IActionResult> UpdateCategoryAsync([FromBody] UpdateCategoryRequest request)
        {
            var result = await _categoryService.UpdateAsync(request);

            if (result.ErrorResponse == null)
            {
                return Ok(result.Response);
            }

            return StatusCode(result.ErrorResponse.ErrorCode, result.ErrorResponse);
        }

        [HttpDelete("category/{categoryId}")]
        public async Task<IActionResult> DeleteCategoryAsync([FromRoute] int categoryId)
        {
            var result = await _categoryService.DeleteAsync(categoryId);

            if (result.ErrorResponse == null)
            {
                return Ok(result.Response);
            }

            return StatusCode(result.ErrorResponse.ErrorCode, result.ErrorResponse);
        }

        [HttpGet("user")]
        public async Task<IActionResult> GetUserListAsync()
        {
            var result = await _userService.GetListAsync();

            return Ok(result.Response);
        }

        [HttpGet("discount")]
        public async Task<IActionResult> GetDiscountListAsync()
        {
            var result = await _discountService.GetListAsync();

            return Ok(result.Response);
        }

        [HttpGet("country")]
        public async Task<IActionResult> GetCountryListAsync()
        {
            var result = await _countryService.GetListAsync();

            return Ok(result.Response);
        }

        [HttpPost("country")]
        public async Task<IActionResult> AddCountry([FromBody] AddCountryRequest request)
        {
            var result = await _countryService.AddAsync(request);

            if (result.ErrorResponse == null)
            {
                return Ok(result.Response);
            }

            return StatusCode(result.ErrorResponse.ErrorCode, result.ErrorResponse);
        }

        [HttpPut("country")]
        public async Task<IActionResult> UpdateCountryAsync([FromBody] UpdateCountryRequest request)
        {
            var result = await _countryService.UpdateAsync(request);

            if (result.ErrorResponse == null)
            {
                return Ok(result.Response);
            }

            return StatusCode(result.ErrorResponse.ErrorCode, result.ErrorResponse);
        }

        [HttpGet("country/dropdown")]
        public async Task<IActionResult> GetCountryDropdownListAsync()
        {
            var result = await _countryService.GetDropdownListAsync();

            return Ok(result.Response);
        }

        [HttpDelete("country/{countryId}")]
        public async Task<IActionResult> DeleteCountryAsync([FromRoute] int countryId)
        {
            var result = await _countryService.DeleteAsync(countryId);

            if (result.ErrorResponse == null)
            {
                return Ok(result.Response);
            }

            return StatusCode(result.ErrorResponse.ErrorCode, result.ErrorResponse);
        }
    }
}