using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using MVC_Project.Api.Middlewares;
using MVC_Project.Logic.Settings;
using System;
using System.Text;

namespace MVC_Project.Api.Configurations
{
    public static class SecurityConfiguration
    {
        public static void AddSecurity(this IServiceCollection services, IConfiguration configuration)
        {
            var swaggerSettings = GetSwaggerSettings(configuration);

            var jwtSettings = new JwtSettings();
            configuration.Bind(nameof(jwtSettings), jwtSettings);

            var tokenValidationParameters = new TokenValidationParameters()
            {
                ValidateIssuerSigningKey = true,
                IssuerSigningKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(jwtSettings.Secret)),
                ValidateIssuer = false,
                ValidateAudience = false,
                RequireExpirationTime = false,
                ValidateLifetime = true
            };

            services.AddSingleton(tokenValidationParameters);

            services.AddAuthentication(x =>
            {
                x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                x.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
                x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            }).AddJwtBearer(x =>
            {
                x.SaveToken = true;
                x.TokenValidationParameters = tokenValidationParameters;
            });

            services.AddAuthorization();

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc(swaggerSettings.Version, new OpenApiInfo { Title = swaggerSettings.Title, Version = swaggerSettings.Version });

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

        public static void UseSecurity(this IApplicationBuilder app, IConfiguration configuration)
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
