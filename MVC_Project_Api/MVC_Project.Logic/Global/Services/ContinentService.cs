using Microsoft.EntityFrameworkCore;
using MVC_Project.Domain;
using MVC_Project.Logic.Commons;
using MVC_Project.Logic.Global.Interfaces;
using MVC_Project.Logic.Global.Responses;
using System.Linq;
using System.Threading.Tasks;

namespace MVC_Project.Logic.Global.Services
{
    public class ContinentService : IContinentService
    {
        private readonly DataContext _dataContext;

        public ContinentService(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        public async Task<HandleResult<GetContinentListResponse>> GetListAsync()
        {
            var result = new HandleResult<GetContinentListResponse>();

            var continents = await _dataContext.Continents.ToListAsync();

            var listItems = continents.Select(x => new ContinentListItem
            {
                ContinentId = x.ContinentId,
                Name = x.Name
            }).ToList();

            var response = new GetContinentListResponse
            {
                Continents = listItems
            };

            result.Response = response;
            return result;
        }
    }
}
