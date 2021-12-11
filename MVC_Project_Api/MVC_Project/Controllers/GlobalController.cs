using Microsoft.AspNetCore.Mvc;
using MVC_Project.Logic.Global.Interfaces;
using System.Threading.Tasks;

namespace MVC_Project.Controllers
{
    [ApiController]
    [Route("global")]
    public class GlobalController : ControllerBase
    {
        private readonly IContinentService _continentService;
        private readonly ICountryService _countryService;

        public GlobalController(IContinentService continentService, ICountryService countryService)
        {
            _continentService = continentService;
            _countryService = countryService;
        }

        [HttpGet("continent")]
        public async Task<IActionResult> GetContinentList()
        {
            var result = await _continentService.GetListAsync();

            return Ok(result.Response);
        }

        [HttpGet("country/{countryId}")]
        public async Task<IActionResult> GetCountryByIdAsync([FromRoute] int countryId)
        {
            var result = await _countryService.GetByIdAsync(countryId);

            if (result.ErrorResponse == null)
            {
                return Ok(result.Response);
            }
            return StatusCode(result.ErrorResponse.ErrorCode, result.ErrorResponse);
        }
    }
}
