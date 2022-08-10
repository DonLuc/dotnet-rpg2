using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using dotnet_rpg.Models;
using dotnet_rpg.Services.CharacterService;
using dotnet_rpg.DTO.Character;

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
        public async Task<ActionResult<ServiceResponse<List<GetCharacterDTO>>>> Get()
        {
            return Ok(await _characterService.GetAllCharacters());
        }

        [HttpGet("GetCharacterById")]
        //[Route("GetCharacterById")]
        public async Task<ActionResult<ServiceResponse<GetCharacterDTO>>> GetCharacterById(int id)
        {
            return Ok(await _characterService.GetCharacterById(id));
        }

        [HttpPost("CreateCharacter")]
        public async Task<ActionResult<ServiceResponse<List<AddCharacterDTO>>>> CreateCharacter([FromBody] AddCharacterDTO character)
        {
            //Console.WriteLine(character);
            var resp = await _characterService.CreateNewCharacter(character);
            return Ok(resp);
        }
    }
}