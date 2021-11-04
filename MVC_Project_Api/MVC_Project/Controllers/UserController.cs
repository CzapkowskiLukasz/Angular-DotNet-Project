using Microsoft.AspNetCore.Mvc;
using MVC_Project.Logic.Interfaces;
using MVC_Project.Logic.Requests;
using System.Threading.Tasks;

namespace MVC_Project.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpPost("login")]
        public async Task<string> LoginAsync(LoginRequest request)
        {
            var result = await _userService.LoginAsync(request);
            return result;
        }


        [HttpPost("register")]
        public async Task<string> RegisterAsync(RegisterRequest request)
        {
            var result = await _userService.RegisterAsync(request);
            return result;
        }
    }
}
