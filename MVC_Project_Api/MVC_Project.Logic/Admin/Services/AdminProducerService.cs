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
    public class AdminProducerService : IAdminProducerService
    {
        private readonly DataContext _dataContext;
        private readonly IMapper _mapper;

        public AdminProducerService(DataContext dataContext, IMapper mapper)
        {
            _dataContext = dataContext;
            _mapper = mapper;
        }

        public async Task<HandleResult<AddProducerResponse>> AddAsync(AddProducerRequest request)
        {
            var result = new HandleResult<AddProducerResponse>();

            if (request == null)
            {
                result.ErrorResponse = new ErrorResponse("Bad request", 400);
                return result;
            }

            var country = await _dataContext.Countries.SingleOrDefaultAsync(x => x.CountryId == request.CountryId);

            if (country == null)
            {
                result.ErrorResponse = new ErrorResponse("Country not found", 404);
            }
            else
            {
                var producer = _mapper.Map<Producer>(request);

                await _dataContext.Producers.AddAsync(producer);
                await _dataContext.SaveChangesAsync();

                result.Response = _mapper.Map<AddProducerResponse>(producer);
            }

            return result;
        }

        public async Task<HandleResult<AdminGetProducerDropdownListResponse>> GetDropdownListAsync()
        {
            var result = new HandleResult<AdminGetProducerDropdownListResponse>();

            var producers = await _dataContext.Producers.ToListAsync();

            result.Response = _mapper.Map<AdminGetProducerDropdownListResponse>(producers);

            return result;
        }

        public async Task<HandleResult<AdminGetProducerListResponse>> GetProducersListAsync()
        {
            var result = new HandleResult<AdminGetProducerListResponse>();

            var producers = await _dataContext.Producers
                .Include(x => x.Country).ToListAsync();

            result.Response = _mapper.Map<AdminGetProducerListResponse>(producers);

            return result;
        }
    }
}
