using AutoMapper;
using Microsoft.AspNetCore.Identity;
using MVC_Project.Domain;
using MVC_Project.Domain.Entities;
using MVC_Project.Logic.Commons;
using MVC_Project.Logic.Customer.Interfaces;
using MVC_Project.Logic.Customer.Requests;
using MVC_Project.Logic.Customer.Responses;
using System.Threading.Tasks;

namespace MVC_Project.Logic.Customer.Services
{
    public class AddressService : IAddressService
    {
        private readonly DataContext _dataContext;
        private readonly IMapper _mapper;
        private readonly UserManager<User> _userManager;

        public AddressService(DataContext dataContext, IMapper mapper, UserManager<User> userManager)
        {
            _dataContext = dataContext;
            _mapper = mapper;
            _userManager = userManager;
        }

        public async Task<HandleResult<AddAddressResponse>> AddAsync(AddAddressRequest request)
        {
            var result = new HandleResult<AddAddressResponse>();

            var user = await _userManager.FindByIdAsync(request.UserId.ToString());

            if (user == null)
            {
                result.ErrorResponse = new ErrorResponse("User not found", 404);
                return result;
            }

            var address = _mapper.Map<Address>(request);

            await _dataContext.Addresses.AddAsync(address);
            var added = await _dataContext.SaveChangesAsync();

            if (added == 1)
            {
                result.Response = new AddAddressResponse
                {
                    Result = true
                };
            }
            else
            {
                result.ErrorResponse = new ErrorResponse("Add address error", 500);
            }

            return result;
        }
    }
}
