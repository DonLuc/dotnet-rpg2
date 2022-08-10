using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using dotnet_rpg.Models;
using dotnet_rpg.Services.CharacterService;

namespace dotnet_rpg.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CharacterController : ControllerBase
    {
        private readonly ICharacterService _characterService;
        public CharacterController(ICharacterService characterService)
        {
            this._characterService = characterService;

        }

        [HttpGet]
        public async Task<ActionResult<ServiceResponse<List<Character>>>> Get()
        {
            return Ok(await _characterService.GetAllCharacters());
        }

        [HttpGet("GetCharacterById")]
        //[Route("GetCharacterById")]
        public async Task<ActionResult<ServiceResponse<Character>>> GetCharacterById(int id)
        {
            return Ok(await _characterService.GetCharacterById(id));
        }

        [HttpPost("CreateCharacter")]
        public async Task<ActionResult<ServiceResponse<List<Character>>>> CreateCharacter([FromBody] Character character)
        {
            //Console.WriteLine(character);
            await _characterService.CreateNewCharacter(character);
            return Ok();
        }
    }
}