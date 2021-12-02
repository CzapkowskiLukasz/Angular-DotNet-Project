using Microsoft.AspNetCore.Http;
using MVC_Project.Logic.Commons;
using MVC_Project.Logic.Files.Images.Interfaces;
using MVC_Project.Logic.Global.Responses;
using System.IO;
using System.Threading.Tasks;

namespace MVC_Project.Logic.Files.Images.Services
{
    public class LocalImageService : IImageService
    {
        private string _folderName = "Resources/Images";

        public async Task<HandleResult<MemoryStream>> DownloadAsync(string fileName)
        {
            var result = new HandleResult<MemoryStream>();

            var path = Path.Combine(Directory.GetCurrentDirectory(), _folderName);
            var fullPath = Path.Combine(path, fileName);

            if (File.Exists(fullPath))
            {
                var memoryStream = new MemoryStream();
                await using (var fileStream = new FileStream(fullPath, FileMode.Open))
                {
                    await fileStream.CopyToAsync(memoryStream);
                }

                memoryStream.Position = 0;
                result.Response = memoryStream;
            }
            else
            {
                result.ErrorResponse = new ErrorResponse("File not exist", 404);
            }
            return result;
        }

        public async Task<HandleResult<MemoryStream>> GetThumbnailAsync(int productId)
        {
            string fileName = $"img-{productId}-thumb";
            string ext = ".jpg";
            var result = await DownloadAsync($"img-{productId}-thumb" + ext);

            if (result.ErrorResponse != null)
            {
                ext = ".png";
                result = await DownloadAsync($"img-{productId}-thumb" + ext);
            }

            return result;
        }

        public async Task<HandleResult<bool>> UploadAsync(IFormFile file, string newName = null)
        {
            var result = new HandleResult<bool>();

            if (file.Length > 0)
            {
                var fileName = newName;
                if (fileName == null)
                {
                    fileName = FileNameHelper.CreateUniqueFileName(file);
                }

                var path = Path.Combine(Directory.GetCurrentDirectory(), _folderName);
                var fullPath = Path.Combine(path, fileName);

                using (var stream = new FileStream(fullPath, FileMode.Create))
                {
                    await file.CopyToAsync(stream);
                }

                result.Response = true;
            }
            else
            {
                result.ErrorResponse = new ErrorResponse("Upload file failed.", 500);
            }

            return result;
        }

        public async Task<HandleResult<bool>> UploadThumbnailAsync(IFormFile file, int productId)
        {
            string newName = GetThumbnailName(productId) + Path.GetExtension(file.FileName);

            var result = await UploadAsync(file, newName);
            return result;
        }

        private string GetThumbnailName(int productId) => $"img-{productId}-thumb";

    }
}
