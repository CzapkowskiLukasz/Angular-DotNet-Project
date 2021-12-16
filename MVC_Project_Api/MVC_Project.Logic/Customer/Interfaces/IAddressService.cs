using MVC_Project.Logic.Commons;
using MVC_Project.Logic.Customer.Requests;
using MVC_Project.Logic.Customer.Responses;
using System.Threading.Tasks;

namespace MVC_Project.Logic.Customer.Interfaces
{
    public interface IAddressService
    {
        public Task<HandleResult<AddAddressResponse>> AddAsync(AddAddressRequest request);
    }
}
