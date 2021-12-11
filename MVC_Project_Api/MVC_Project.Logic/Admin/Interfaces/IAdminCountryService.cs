using MVC_Project.Logic.Admin.Requests;
using MVC_Project.Logic.Admin.Responses;
using MVC_Project.Logic.Commons;
using System.Threading.Tasks;

namespace MVC_Project.Logic.Admin.Interfaces
{
    public interface IAdminCountryService
    {
        public Task<HandleResult<AdminGetCountryListResponse>> GetListAsync();

        public Task<HandleResult<AdminGetCountryDropdownListResponse>> GetDropdownListAsync();

        public Task<HandleResult<AddCountryResponse>> AddAsync(AddCountryRequest request);

        public Task<HandleResult<UpdateCountryResponse>> UpdateAsync(UpdateCountryRequest request);

        public Task<HandleResult<bool>> DeleteAsync(int countryId);
    }
}
