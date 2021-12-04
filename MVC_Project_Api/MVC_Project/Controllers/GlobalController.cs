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

        public GlobalController(IContinentService continentService)
        {
            _continentService = continentService;
        }

        [HttpGet("continent")]
        public async Task<IActionResult> GetContinentList()
        {
            var result = await _continentService.GetListAsync();

            return Ok(result.Response);
        }
    }
}
