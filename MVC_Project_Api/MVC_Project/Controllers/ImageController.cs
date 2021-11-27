using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MVC_Project.Logic.Files.Images.Interfaces;
using System.Threading.Tasks;

namespace MVC_Project.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ImageController : Controller
    {
        private readonly IImageService _imageService;

        public ImageController(IImageServiceFactory imageServiceFactory)
        {
            _imageService = imageServiceFactory.GetImageService();
        }

        [HttpGet("product-thumbnail/{productId}"), DisableRequestSizeLimit]
        public async Task<IActionResult> GetImage([FromRoute] int productId)
        {
            var result = await _imageService.GetThumbnailAsync(productId);

            if (result.ErrorResponse == null)
            {
                var memoryStream = result.Response;
                return File(memoryStream, "image/jpg");
            }
            else
            {
                return StatusCode(result.ErrorResponse.ErrorCode, result.ErrorResponse);
            }
        }

        [HttpPost]
        public async Task<IActionResult> UploadAsync([FromForm] IFormFile file)
        {
            var result = await _imageService.UploadAsync(file);

            if (result.ErrorResponse == null)
            {
                return Ok(result.Response);
            }
            else
            {
                return StatusCode(result.ErrorResponse.ErrorCode, result.ErrorResponse);
            }
        }

        [HttpPost("{productId}")]
        public async Task<IActionResult> UploadThumbnailAsync([FromForm] IFormFile file, [FromRoute] int productId)
        {
            var result = await _imageService.UploadThumbnailAsync(file, productId);

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
