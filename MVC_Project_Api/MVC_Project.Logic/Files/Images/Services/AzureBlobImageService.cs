using Azure.Storage.Blobs;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Options;
using MVC_Project.Logic.Commons;
using MVC_Project.Logic.Files.Images.Interfaces;
using MVC_Project.Logic.Settings;
using System.IO;
using System.Threading.Tasks;

namespace MVC_Project.Logic.Files.Images.Services
{
    public class AzureBlobImageService : IImageService
    {
        protected readonly AzureBlobSettings _settings;

        private BlobServiceClient _blobServiceClient;

        private BlobContainerClient _containerClient;

        public AzureBlobImageService(IOptions<AzureBlobSettings> settings)
        {
            _settings = settings.Value;
            _blobServiceClient = new BlobServiceClient(_settings.ConnectionString);
            _containerClient = _blobServiceClient.GetBlobContainerClient(_settings.ImagesContainerName);
        }

        public async Task<HandleResult<MemoryStream>> DownloadAsync(string fileName)
        {
            var result = new HandleResult<MemoryStream>();

            var blobClient = _containerClient.GetBlobClient(fileName);
            var memoryStream = new MemoryStream();
            await blobClient.DownloadToAsync(memoryStream);

            if (memoryStream.Length > 0)
            {
                memoryStream.Position = 0;
                result.Response = memoryStream;
            }
            else
            {
                result.ErrorResponse = new ErrorResponse("File not exist", 404);
            }
            return result;
        }

        public Task<HandleResult<MemoryStream>> GetThumbnailAsync(int productId)
        {
            throw new System.NotImplementedException();
        }

        public async Task<HandleResult<bool>> UploadAsync(IFormFile file, string newName = null)
        {
            var result = new HandleResult<bool>();

            var fileName = FileNameHelper.CreateUniqueFileName(file);

            using (var stream = new MemoryStream())
            {
                await file.CopyToAsync(stream);
                stream.Position = 0;

                var blobClient = _containerClient.GetBlobClient(fileName);
                await blobClient.UploadAsync(stream);

                if (await blobClient.ExistsAsync())
                {
                    result.Response = true;
                }
                else
                {
                    result.ErrorResponse = new ErrorResponse("Upload file failed.", 500);
                }
            }

            return result;
        }

        public Task<HandleResult<bool>> UploadThumbnailAsync(IFormFile file, int productId)
        {
            throw new System.NotImplementedException();
        }
    }
}
