using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using MVC_Project.Logic.Interfaces;
using MVC_Project.Logic.Requests;
using System;
using System.Collections.Generic;
using System.Linq;
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

        [HttpPost("register")]
        public async Task<string> Register(RegisterRequest request)
        {
            var result = await _userService.RegisterAsync(request);
            return result;
        }
    }
}
