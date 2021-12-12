﻿using AutoMapper;
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

        public async Task<HandleResult<bool>> DeleteAsync(int producerId)
        {
            var result = new HandleResult<bool>();

            var producer = await _dataContext.Producers.Include(x => x.Products)
                .SingleOrDefaultAsync(x => x.ProducerId == producerId);

            if (producer == null)
            {
                result.ErrorResponse = new ErrorResponse("Producer not found", 404);
                return result;
            }

            if (producer.Products.Count > 0)
            {
                result.ErrorResponse = new ErrorResponse("Producer has products", 400);
                return result;
            }

            _dataContext.Producers.Remove(producer);
            var deleted = await _dataContext.SaveChangesAsync();

            if (deleted != 1)
            {
                result.ErrorResponse = new ErrorResponse("Delete error", 500);
            }
            else
            {
                result.Response = true;
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

        public async Task<HandleResult<UpdateProducerResponse>> UpdateAsync(UpdateProducerRequest request)
        {
            var result = new HandleResult<UpdateProducerResponse>();

            if (request == null)
            {
                result.ErrorResponse = new ErrorResponse("Bad request", 400);
                return result;
            }

            var producer = await _dataContext.Producers
                .SingleOrDefaultAsync(x => x.ProducerId == request.ProducerId);

            if (producer == null)
            {
                result.ErrorResponse = new ErrorResponse("Producer not found", 404);
                return result;
            }

            var country = await _dataContext.Countries.SingleOrDefaultAsync(x => x.CountryId == request.CountryId);

            if (country == null)
            {
                result.ErrorResponse = new ErrorResponse("Country not found", 404);
                return result;
            }

            producer = _mapper.Map<UpdateProducerRequest, Producer>(request, producer);

            var updated = await _dataContext.SaveChangesAsync();

            if (updated == 1)
            {
                result.Response = _mapper.Map<UpdateProducerResponse>(producer);
            }
            else
            {
                result.ErrorResponse = new ErrorResponse("Update error", 500);
            }

            return result;
        }
    }
}
