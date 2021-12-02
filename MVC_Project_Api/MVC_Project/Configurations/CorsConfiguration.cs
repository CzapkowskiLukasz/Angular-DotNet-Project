using Microsoft.Extensions.DependencyInjection;

namespace MVC_Project.Api.Configurations
{
    public static class CorsConfiguration
    {
        public static void AddCustomCors(this IServiceCollection services)
        {
            services.AddCors(options =>
                options.AddDefaultPolicy(builder => builder
                   .AllowAnyMethod()
                   .AllowAnyHeader()
                   .WithOrigins("http://localhost:4200"))
            );
        }
    }
}
