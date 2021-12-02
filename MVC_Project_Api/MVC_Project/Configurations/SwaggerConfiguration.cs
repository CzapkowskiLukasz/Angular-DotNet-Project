using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;
using MVC_Project.Api.Filters;
using MVC_Project.Api.Middlewares;
using MVC_Project.Logic.Settings;
using System;

namespace MVC_Project.Api.Configurations
{
    public static class SwaggerConfiguration
    {
        public static void AddSwagger(this IServiceCollection services, IConfiguration configuration)
        {
            var swaggerSettings = GetSwaggerSettings(configuration);
            services.AddSingleton(swaggerSettings);

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc(swaggerSettings.Version, new OpenApiInfo { Title = swaggerSettings.Title, Version = swaggerSettings.Version });

                c.OperationFilter<SwaggerFileOperationFilter>();

                c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
                {
                    Name = "Authorization",
                    Description = "JWT Authorization header using the bearer scheme",
                    In = ParameterLocation.Header,
                    Type = SecuritySchemeType.ApiKey
                });

                c.AddSecurityRequirement(new OpenApiSecurityRequirement
                    {
                    {
                        new OpenApiSecurityScheme
                        {
                            Reference = new OpenApiReference
                            {
                                Id = "Bearer",
                                Type = ReferenceType.SecurityScheme
                            }
                        },
                        Array.Empty<string>()
                    }
                    });
            });
        }

        public static void UseSwagger(this IApplicationBuilder app, IConfiguration configuration)
        {
            var swaggerSettings = GetSwaggerSettings(configuration);
            var description = $"{swaggerSettings.Title} {swaggerSettings.Version}";

            app.UseMiddleware<SwaggerAuthenticationMiddleware>();

            app.UseSwagger();
            app.UseSwaggerUI(c => c.SwaggerEndpoint(swaggerSettings.UIEndpoint, description));
        }

        private static SwaggerSettings GetSwaggerSettings(IConfiguration configuration)
        {
            var swaggerSettings = new SwaggerSettings();
            configuration.Bind(nameof(swaggerSettings), swaggerSettings);

            return swaggerSettings;
        }
    }
}
