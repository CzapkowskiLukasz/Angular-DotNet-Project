﻿using MVC_Project.Logic.Admin.Responses;
using MVC_Project.Logic.Commons;
using System.Threading.Tasks;

namespace MVC_Project.Logic.Admin.Interfaces
{
    public interface IAdminProducerService
    {
        public Task<HandleResult<AdminGetProducerListResponse>> GetProducersListAsync();
    }
}
