using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using dotnet_rpg.Models;

namespace dotnet_rpg.Services.CharacterService
{
    public class CharacterService : ICharacterService
    {
        public static List<Character> characters = new List<Character> {
            new Character(),
            new Character{Name = "Picachu" },
            new Character{Name = "Spider-Man" }
        };
        public async Task<ServiceResponse<List<Character>>> CreateNewCharacter(Character character)
        {
            var serviceResponse = new ServiceResponse<List<Character>>();
            characters.Add(character);
            serviceResponse.Data = characters;

            return serviceResponse;
        }

        public async Task<ServiceResponse<List<Character>>> GetAllCharacters()
        {
            return new ServiceResponse<List<Character>>
            {
                Data = characters
            };
        }

        public async Task<ServiceResponse<Character>> GetCharacterById(int id)
        {
            var serviceResponse = new ServiceResponse<Character>
            {
                Data = characters.FirstOrDefault(c => c.Id == id)
            };
            return serviceResponse;
            //return characters.FirstOrDefault(c => c.Id == id);
        }
    }
}