using AutoMapper;
using Microsoft.EntityFrameworkCore;
using MVC_Project.Domain;
using MVC_Project.Domain.Entities;
using MVC_Project.Logic.Admin.Interfaces;
using MVC_Project.Logic.Admin.Requests;
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

        public async Task<HandleResult<AddCountryResponse>> AddAsync(AddCountryRequest request)
        {
            var result = new HandleResult<AddCountryResponse>();

            if (request == null || string.IsNullOrEmpty(request.Name))
            {
                result.ErrorResponse = new ErrorResponse("Bad request", 400);
                return result;
            }

            var continent = await _dataContext.Continents
                .SingleOrDefaultAsync(x => x.ContinentId == request.ContinentId);

            if (continent == null)
            {
                result.ErrorResponse = new ErrorResponse("Continent not found", 404);
                return result;
            }

            var country = _mapper.Map<Country>(request);

            await _dataContext.AddAsync(country);
            await _dataContext.SaveChangesAsync();

            result.Response = _mapper.Map<AddCountryResponse>(country);
            return result;
        }

        public async Task<HandleResult<bool>> DeleteAsync(int countryId)
        {
            var result = new HandleResult<bool>();

            var country = await _dataContext.Countries.Include(x => x.Producers)
                .SingleOrDefaultAsync(x => x.CountryId == countryId);

            if (country == null)
            {
                result.ErrorResponse = new ErrorResponse("Country not found", 404);
                return result;
            }

            if (country.Producers.Count > 0)
            {
                result.ErrorResponse = new ErrorResponse("Country has producers", 400);
                return result;
            }

            _dataContext.Countries.Remove(country);
            var deleted = await _dataContext.SaveChangesAsync();

            result.Response = deleted == 1;
            return result;
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

        public async Task<HandleResult<UpdateCountryResponse>> UpdateAsync(UpdateCountryRequest request)
        {
            var result = new HandleResult<UpdateCountryResponse>();

            if (request == null || string.IsNullOrEmpty(request.Name))
            {
                result.ErrorResponse = new ErrorResponse("Bad request", 400);
                return result;
            }

            var country = await _dataContext.Countries
                .SingleOrDefaultAsync(x => x.CountryId == request.CountryId);

            if (country == null)
            {
                result.ErrorResponse = new ErrorResponse("Country not found", 404);
                return result;
            }

            var continent = await _dataContext.Continents
                .SingleOrDefaultAsync(x => x.ContinentId == request.ContinentId);

            if (continent == null)
            {
                result.ErrorResponse = new ErrorResponse("Continent not found", 404);
                return result;
            }

            country = _mapper.Map<UpdateCountryRequest, Country>(request, country);

            await _dataContext.SaveChangesAsync();

            result.Response = _mapper.Map<UpdateCountryResponse>(country);
            return result;
        }
    }
}
