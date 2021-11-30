using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using MVC_Project.Api.Configurations;
using MVC_Project.Api.Middlewares;
using MVC_Project.Domain;
using MVC_Project.Domain.Entities;
using MVC_Project.Logic;
using MVC_Project.Logic.Files.Images.Interfaces;
using MVC_Project.Logic.Files.Images.Services;
using MVC_Project.Logic.Interfaces;
using MVC_Project.Logic.Products.Interfaces;
using MVC_Project.Logic.Products.Services;
using MVC_Project.Logic.Services;
using MVC_Project.Logic.Settings;

namespace MVC_Project
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddCors(options =>
                options.AddDefaultPolicy( builder => builder
                    .AllowAnyMethod()
                    .AllowAnyHeader()
                    .WithOrigins("http://localhost:4200"))
            );


            services.AddDbContext<DataContext>(options =>
                options.UseSqlServer(
                    Configuration.GetConnectionString("DefaultConnection")));

            services.AddIdentity<User, IdentityRole<int>>()
                .AddEntityFrameworkStores<DataContext>();

            services.AddAutoMapper(typeof(LogicEntryPoint).Assembly);

            services.AddScoped<IUserService, UserService>();
            services.AddScoped<IProductService, ProductService>();
            services.AddScoped<IOrderService, OrderService>();

            services.AddScoped<IAdminProductService, AdminProductService>();

            services.AddControllers();

            services.AddSecurity(Configuration);


            services.Configure<ProvidersSettings>(Configuration.GetSection("ProvidersSettings"));

            //services.Configure<AzureBlobSettings>(Configuration.GetSection("AzureBlobSettings"));

            services.AddTransient<IImageServiceFactory, ImageServiceFactory>();
            //services.AddTransient<AzureBlobImageService>()
            //    .AddTransient<IImageService, AzureBlobImageService>(s => s.GetService<AzureBlobImageService>());
            services.AddTransient<LocalImageService>()
                .AddTransient<IImageService, LocalImageService>(s => s.GetService<LocalImageService>());

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseCors();
            app.UseSecurity(Configuration);

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseMiddleware<ExceptionMiddleware>();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

        }
    }
}
