using Microsoft.Extensions.Options;
using MVC_Project.Logic.Files.Images.Interfaces;
using MVC_Project.Logic.Settings;
using System;

namespace MVC_Project.Logic.Files.Images.Services
{
    public class ImageServiceFactory : IImageServiceFactory
    {
        private readonly IServiceProvider _serviceProvider;
        private readonly ProvidersSettings _settings;

        public ImageServiceFactory(IServiceProvider serviceProvider, IOptions<ProvidersSettings> settings)
        {
            _serviceProvider = serviceProvider;
            _settings = settings.Value;
        }

        public IImageService GetImageService()
        {
            var type = _settings.StorageType;
            switch (type)
            {
                case "Azure":
                    return (IImageService)_serviceProvider.GetService(typeof(AzureBlobImageService));

                case "Local":
                    return (IImageService)_serviceProvider.GetService(typeof(LocalImageService));

                default:
                  throw new Exception("Wrong storage service type.");
            }
        }
    }
}
