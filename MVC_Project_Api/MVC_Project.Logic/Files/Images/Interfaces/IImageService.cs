using System.IO;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using MVC_Project.Logic.Responses;

namespace MVC_Project.Logic.Files.Images.Interfaces
{
    public interface IImageService
    {
        public Task<HandleResult<MemoryStream>> DownloadAsync(string fileName);

        public Task<HandleResult<MemoryStream>> GetThumbnailAsync(int productId);

        public Task<HandleResult<bool>> UploadAsync(IFormFile file, string newName = null);

        public Task<HandleResult<bool>> UploadThumbnailAsync(IFormFile file, int productId);
    }
}
