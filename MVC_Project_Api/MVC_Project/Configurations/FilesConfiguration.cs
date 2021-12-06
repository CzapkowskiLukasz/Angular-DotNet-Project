using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using MVC_Project.Logic.Files.Images.Interfaces;
using MVC_Project.Logic.Files.Images.Services;
using MVC_Project.Logic.Settings;

namespace MVC_Project.Api.Configurations
{
    public static class FilesConfiguration
    {
        public static void AddFiles(this IServiceCollection services, IConfiguration configuration)
        {
            services.Configure<ProvidersSettings>(configuration.GetSection("ProvidersSettings"));

            //services.Configure<AzureBlobSettings>(Configuration.GetSection("AzureBlobSettings"));

            services.AddTransient<IImageServiceFactory, ImageServiceFactory>();
            //services.AddTransient<AzureBlobImageService>()
            //    .AddTransient<IImageService, AzureBlobImageService>(s => s.GetService<AzureBlobImageService>());
            services.AddTransient<LocalImageService>()
                .AddTransient<IImageService, LocalImageService>(s => s.GetService<LocalImageService>());
        }
    }
}
