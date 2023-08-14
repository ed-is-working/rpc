// global availability
// TODO: remove this as it is added in Program.cs
global using rpc.Models;
global using rpc.Services.CharacterService;

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;


namespace rpc.Controllers
{
        [ApiController]
        [Route("api/[controller]")]

    // TODO: is it better to use ControllerBase or Controller?
    public class CharacterController : Controller
    {

        private readonly ILogger<CharacterController> _logger;
        private readonly ICharacterService _characterService;

        public CharacterController(ICharacterService characterService, ILogger<CharacterController> logger)
        {
            _characterService = characterService;
            _logger = logger;
        }

       [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]

        // update return type to show list of characters
        [HttpGet("GetAll")]
        public async Task<ActionResult<List<Character>>> Get()
        {
            // can also implement BadRequest or NotFound
            return Ok(await _characterService.GetAllCharacters());
        }

        // return single character
        [HttpGet("{id}")]
        public async Task<ActionResult<Character>> GetSingle(int id)
        {
            // can also implement BadRequest or NotFound
            return Ok(await _characterService.GetCharacterById(id));
        }

        // add character (C in CRUD)
        [HttpPost]
        public async Task<ActionResult<List<Character>>> AddCharacter(Character newCharacter)
        {
            // TODO: add validation, ensure that a character with the same name / Id does not already exist
            return Ok(await _characterService.AddCharacter(newCharacter));
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