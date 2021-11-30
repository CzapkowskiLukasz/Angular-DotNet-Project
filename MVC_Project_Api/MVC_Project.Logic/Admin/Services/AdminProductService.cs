using AutoMapper;
using Microsoft.EntityFrameworkCore;
using MVC_Project.Domain;
using MVC_Project.Logic.Admin.Interfaces;
using MVC_Project.Logic.Admin.Responses;
using MVC_Project.Logic.Commons;
using System.Threading.Tasks;

namespace MVC_Project.Logic.Admin.Services
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
