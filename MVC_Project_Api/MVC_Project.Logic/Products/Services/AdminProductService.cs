using AutoMapper;
using Microsoft.EntityFrameworkCore;
using MVC_Project.Domain;
using MVC_Project.Logic.Products.Interfaces;
using MVC_Project.Logic.Products.Responses;
using MVC_Project.Logic.Responses;
using System.Threading.Tasks;

namespace MVC_Project.Logic.Products.Services
{
    public class AdminProductService : IAdminProductService
    {
        private readonly DataContext _dataContext;
        private readonly IMapper _mapper;

        public AdminProductService(DataContext dataContext, IMapper mapper)
        {
            _dataContext = dataContext;
            _mapper = mapper;
        }

        public async Task<HandleResult<AdminGetProductListResponse>> GetProductListAsync()
        {
            var result = new HandleResult<AdminGetProductListResponse>();

            var products = await _dataContext.Products
                .Include(x => x.Producer).ToListAsync();

            result.Response = _mapper.Map<AdminGetProductListResponse>(products);

            return result;
        }
    }
}
