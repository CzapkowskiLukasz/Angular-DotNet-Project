using System;
using System.Threading.Tasks;
using MVC_Project.Logic.Commons;
using MVC_Project.Logic.Customer.Responses;

namespace MVC_Project.Logic.Customer.Interfaces
{
    public interface ICustomerAddressService
    {
        public Task<HandleResult<GetAddressesResponse>> GetAddressesByUser(int userId);
    }
}
