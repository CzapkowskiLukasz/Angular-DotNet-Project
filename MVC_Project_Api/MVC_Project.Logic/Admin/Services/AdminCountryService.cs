using AutoMapper;
using Microsoft.EntityFrameworkCore;
using MVC_Project.Domain;
using MVC_Project.Logic.Admin.Interfaces;
using MVC_Project.Logic.Admin.Responses;
using MVC_Project.Logic.Commons;
using System.Threading.Tasks;

namespace MVC_Project.Logic.Admin.Services
{
    public class AdminCountryService : IAdminCountryService
    {
        private readonly DataContext _dataContext;
        private readonly IMapper _mapper;

        public AdminCountryService(DataContext dataContext, IMapper mapper)
        {
            _dataContext = dataContext;
            _mapper = mapper;
        }

        public async Task<HandleResult<AdminGetCountryDropdownListResponse>> GetDropdownListAsync()
        {
            var result = new HandleResult<AdminGetCountryDropdownListResponse>();

            var countries = await _dataContext.Countries.ToListAsync();

            result.Response = _mapper.Map<AdminGetCountryDropdownListResponse>(countries);

            return result;
        }

        public async Task<HandleResult<AdminGetCountryListResponse>> GetListAsync()
        {
            var result = new HandleResult<AdminGetCountryListResponse>();

            var countries = await _dataContext.Countries
                .Include(x => x.Continent).ToListAsync();

            result.Response = _mapper.Map<AdminGetCountryListResponse>(countries);

            return result;
        }
    }
}
