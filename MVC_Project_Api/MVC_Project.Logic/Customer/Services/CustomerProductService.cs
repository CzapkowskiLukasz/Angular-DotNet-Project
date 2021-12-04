using AutoMapper;
using Microsoft.EntityFrameworkCore;
using MVC_Project.Domain;
using MVC_Project.Logic.Commons;
using MVC_Project.Logic.Customer.Interfaces;
using MVC_Project.Logic.Customer.Responses;
using System.Linq;
using System.Threading.Tasks;

namespace MVC_Project.Logic.Customer.Services
{
    public class CustomerProductService : ICustomerProductService
    {
        private readonly DataContext _dataContext;
        private readonly IMapper _mapper;

        public CustomerProductService(DataContext dataContext, IMapper mapper)
        {
            _dataContext = dataContext;
            _mapper = mapper;
        }

        public async Task<HandleResult<GetBestsellersResponse>> GetBestsellersAsync(int count)
        {
            var result = new HandleResult<GetBestsellersResponse>();

            var products = await _dataContext.Products
                .Include(x => x.Producer).ToListAsync();

            var bestsellers = products.OrderByDescending(x => x.SoldCount).Take(count).ToList();

            result.Response = _mapper.Map<GetBestsellersResponse>(bestsellers);

            return result;
        }
    }
}
