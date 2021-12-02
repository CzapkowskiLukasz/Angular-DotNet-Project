using AutoMapper;
using Microsoft.EntityFrameworkCore;
using MVC_Project.Domain;
using MVC_Project.Logic.Admin.Interfaces;
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
