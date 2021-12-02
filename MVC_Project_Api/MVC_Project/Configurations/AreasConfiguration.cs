using Microsoft.Extensions.DependencyInjection;
using MVC_Project.Logic;
using MVC_Project.Logic.Admin.Interfaces;
using MVC_Project.Logic.Admin.Services;
using MVC_Project.Logic.Global.Interfaces;
using MVC_Project.Logic.Global.Services;
using MVC_Project.Logic.Warehouse.Interfaces;
using MVC_Project.Logic.Warehouse.Services;

namespace MVC_Project.Api.Configurations
{
    public static class AreasConfiguration
    {
        public static void AddGlobalArea(this IServiceCollection services)
        {
            services.AddAutoMapper(typeof(LogicEntryPoint).Assembly);

            services.AddScoped<IUserService, UserService>();
        }

        public static void AddAdminArea(this IServiceCollection services)
        {
            services.AddScoped<IAdminCategoryService, AdminCategoryService>();
            services.AddScoped<IAdminDiscountService, AdminDiscountService>();
            services.AddScoped<IAdminProducerService, AdminProducerService>();
            services.AddScoped<IAdminProductService, AdminProductService>();
            services.AddScoped<IAdminUserService, AdminUserService>();
        }

        public static void AddWarehouseArea(this IServiceCollection services)
        {
            services.AddScoped<IProductService, ProductService>();
            services.AddScoped<IOrderService, OrderService>();
        }
    }
}
