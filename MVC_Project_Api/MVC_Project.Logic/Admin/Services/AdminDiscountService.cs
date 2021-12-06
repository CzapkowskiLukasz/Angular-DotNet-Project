using AutoMapper;
using Microsoft.EntityFrameworkCore;
using MVC_Project.Domain;
using MVC_Project.Logic.Admin.Interfaces;
using MVC_Project.Logic.Admin.Responses;
using MVC_Project.Logic.Commons;
using System.Threading.Tasks;

namespace MVC_Project.Logic.Admin.Services
{
    public class AdminDiscountService : IAdminDiscountService
    {
        private readonly DataContext _dataContext;
        private readonly IMapper _mapper;

        public AdminDiscountService(DataContext dataContext, IMapper mapper)
        {
            _dataContext = dataContext;
            _mapper = mapper;
        }

        public async Task<HandleResult<AdminGetDiscountListResponse>> GetListAsync()
        {
            var result = new HandleResult<AdminGetDiscountListResponse>();

            var discounts = await _dataContext.Discounts.ToListAsync();

            result.Response = _mapper.Map<AdminGetDiscountListResponse>(discounts);

            return result;
        }
    }
}
