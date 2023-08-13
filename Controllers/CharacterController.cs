using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using rpc.Models;

namespace rpc.Controllers
{
        [ApiController]
        [Route("api/[controller]")]

    // TODO: is it better to use ControllerBase or Controller?
    public class CharacterController : Controller
    {

        private readonly ILogger<CharacterController> _logger;

        // enable list of characters
        private static List<Character> characters = new List<Character>
        {
            new Character(),
            new Character { Id = 2, Name = "Sam" }
        };

        public CharacterController(ILogger<CharacterController> logger)
        {
            _logger = logger;
        }

        // update return type to show list of characters
        [HttpGet]
        public ActionResult<List<Character>> Get()
        {
            // can also implement BadRequest or NotFound
            return Ok(characters);
        }

        [NonAction]
        public IActionResult Index()
        {
            return View();
        }

       [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]

       [ApiExplorerSettings(IgnoreApi = true)]
        public IActionResult Error()
        {
            return View("Error!");
        }
    }
}