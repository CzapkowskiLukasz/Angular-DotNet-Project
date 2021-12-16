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
    public class CustomerAddressService : ICustomerAddressService
    {
        private readonly DataContext _dataContext;
        private readonly IMapper _mapper;

        public CustomerAddressService(DataContext dataContext, IMapper mapper)
        {
            _dataContext = dataContext;
            _mapper = mapper;
        }

        public async Task<HandleResult<GetAddressesResponse>> GetAddressesByUser(int userId)
        {
            var result = new HandleResult<GetAddressesResponse>();

            var addresses = await _dataContext.Addresses.Where(x=> x.UserId == userId)

            .ToListAsync();

            result.Response = _mapper.Map<GetAddressesResponse>(addresses);

            return result;
        }
    }
}
