using MVC_Project.Logic.Admin.Requests;
using MVC_Project.Logic.Admin.Responses;
using MVC_Project.Logic.Commons;
using System.Threading.Tasks;

namespace MVC_Project.Logic.Admin.Interfaces
{
    public interface IAdminProducerService
    {
        public Task<HandleResult<AdminGetProducerListResponse>> GetProducersListAsync();

        public Task<HandleResult<AdminGetProducerDropdownListResponse>> GetDropdownListAsync();

        public Task<HandleResult<AddProducerResponse>> AddAsync(AddProducerRequest request);

        public Task<HandleResult<UpdateProducerResponse>> UpdateAsync(UpdateProducerRequest request);

        public Task<HandleResult<bool>> DeleteAsync(int producerId);
    }
}
