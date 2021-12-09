using MVC_Project.Logic.Commons;
using MVC_Project.Logic.Global.Responses;
using System.Threading.Tasks;

namespace MVC_Project.Logic.Global.Interfaces
{
    public interface ICountryService
    {
        public Task<HandleResult<GetCountryByIdResponse>> GetByIdAsync(int countryId);
    }
}
