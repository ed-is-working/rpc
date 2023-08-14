using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using rpc.DTOs.User;

namespace rpc.Controllers
{
    [ApiController]
    [Route("[controller]")]

    public class AuthController : Controller
    {
        private readonly IAuthRepository _authRepo;
        private readonly ILogger<AuthController> _logger;

        public AuthController(IAuthRepository authRepo, ILogger<AuthController> logger)
        {
            _authRepo = authRepo;
            _logger = logger;
        }

        [HttpPost("Register")]
        public async Task<ActionResult<ServiceResponse<int>>> Register(UserRegisterDTO request)
        {
            // this allows flexibility in the request body to be able to 
            // other info in additon to username and password
            var response = await _authRepo.Register(
                new User { Username = request.Username }, request.Password
            );

            // check if the response is successful
            if(!response.Success)
            {
                return BadRequest(response);
            }
            return Ok(response);
        }


        [NonAction]
        [ApiExplorerSettings(IgnoreApi = true)]
        public IActionResult Index()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]

        [NonAction]
        [ApiExplorerSettings(IgnoreApi = true)]
        public IActionResult Error()
        {
            return View("Error!");
        }
    }


}