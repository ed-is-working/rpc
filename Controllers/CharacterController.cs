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
            new Character { Id = 1, Name = "Sam" }
        };

        public CharacterController(ILogger<CharacterController> logger)
        {
            _logger = logger;
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]

        // update return type to show list of characters
        [HttpGet("GetAll")]
        public ActionResult<List<Character>> Get()
        {
            // can also implement BadRequest or NotFound
            return Ok(characters);
        }

        // return single character
        [HttpGet("{id}")]
        public ActionResult<Character> GetSingle(int id)
        {
            // can also implement BadRequest or NotFound
            return Ok(characters.FirstOrDefault(c => c.Id == id));
        }

        // add character (C in CRUD)
        [HttpPost]
        public ActionResult<List<Character>> AddCharacter(Character newCharacter)
        {
            // TODO: add validation, ensure that a character with the same name / Id does not already exist
            characters.Add(newCharacter);
            return Ok(characters);
        }

        [NonAction]
        public IActionResult Index()
        {
            return View();
        }


       [ApiExplorerSettings(IgnoreApi = true)]
        public IActionResult Error()
        {
            return View("Error!");
        }
    }
}