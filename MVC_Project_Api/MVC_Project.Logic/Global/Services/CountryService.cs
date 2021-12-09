using AutoMapper;
using Microsoft.EntityFrameworkCore;
using MVC_Project.Domain;
using MVC_Project.Logic.Commons;
using MVC_Project.Logic.Global.Interfaces;
using MVC_Project.Logic.Global.Responses;
using System.Threading.Tasks;

namespace MVC_Project.Logic.Global.Services
{
    public class CountryService : ICountryService
    {
        private readonly DataContext _dataContext;
        private readonly IMapper _mapper;

        public CountryService(DataContext dataContext, IMapper mapper)
        {
            _dataContext = dataContext;
            _mapper = mapper;
        }

        public async Task<HandleResult<GetCountryByIdResponse>> GetByIdAsync(int countryId)
        {
            var result = new HandleResult<GetCountryByIdResponse>();

            var country = await _dataContext.Countries.Include(x => x.Continent)
                .SingleOrDefaultAsync(x => x.CountryId == countryId);

            if (country == null)
            {
                result.ErrorResponse = new ErrorResponse("Country not found", 404);
            }
            else
            {
                result.Response = _mapper.Map<GetCountryByIdResponse>(country);
            }

            return result;
        }
    }
}
