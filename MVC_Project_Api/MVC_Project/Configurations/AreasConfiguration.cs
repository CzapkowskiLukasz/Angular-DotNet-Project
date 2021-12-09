using Microsoft.Extensions.DependencyInjection;
using MVC_Project.Logic;
using MVC_Project.Logic.Admin.Interfaces;
using MVC_Project.Logic.Admin.Services;
using MVC_Project.Logic.Customer.Interfaces;
using MVC_Project.Logic.Customer.Services;
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
            services.AddScoped<IContinentService, ContinentService>();
            services.AddScoped<ICountryService, CountryService>();
        }

        public static void AddAdminArea(this IServiceCollection services)
        {
            services.AddScoped<IAdminCategoryService, AdminCategoryService>();
            services.AddScoped<IAdminCountryService, AdminCountryService>();
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

        public static void AddCustomerArea(this IServiceCollection services)
        {
            services.AddScoped<ICustomerProductService, CustomerProductService>();
        }

        public static void AddAreas(this IServiceCollection services)
        {
            services.AddGlobalArea();
            services.AddAdminArea();
            services.AddWarehouseArea();
            services.AddCustomerArea();
        }
    }
}
