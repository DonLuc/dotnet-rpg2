using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using dotnet_rpg.Models;


namespace dotnet_rpg.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CharacterController : ControllerBase
    {
        //private static Character knight = new Character();
        private static List<Character> characters = new List<Character> {
            new Character(),
            new Character{Name = "Picachu" },
            new Character{Name = "Spider-Man" }
        };


        [HttpGet]
        public ActionResult<List<Character>> Get()
        {
            return Ok(characters);
        }

        [HttpGet("GetCharacterById")]
        public ActionResult<Character> GetCharacterById(int id)
        {
            if (id > characters.Count)
            {
                return BadRequest();
            }
            return Ok(characters[id]);
        }


    }
}