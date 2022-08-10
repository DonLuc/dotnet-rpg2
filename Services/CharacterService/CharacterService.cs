using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using dotnet_rpg.DTO.Character;
using dotnet_rpg.Models;

namespace dotnet_rpg.Services.CharacterService
{
    public class CharacterService : ICharacterService
    {

        public static List<Character> characters = new List<Character> {
            new Character(),
            new Character{Name = "Picachu", Id = 1 },
            new Character{Name = "Spider-Man" }
        };
        private readonly IMapper _mapper;

        public CharacterService(IMapper mapper)
        {
            this._mapper = mapper;
        }

        public async Task<ServiceResponse<List<GetCharacterDTO>>> CreateNewCharacter(AddCharacterDTO character)
        {
            var serviceResponse = new ServiceResponse<List<GetCharacterDTO>>();

            Character myCharacter = _mapper.Map<Character>(character);
            myCharacter.Id = characters.Max(c => c.Id) + 1;
            characters.Add(myCharacter);
            serviceResponse.Data = characters.Select(c => _mapper.Map<GetCharacterDTO>(c)).ToList();

            return serviceResponse;
        }

        public async Task<ServiceResponse<List<GetCharacterDTO>>> GetAllCharacters()
        {
            return new ServiceResponse<List<GetCharacterDTO>>
            {
                Data = characters.Select(c => _mapper.Map<GetCharacterDTO>(c)).ToList()
            };
        }

        public async Task<ServiceResponse<GetCharacterDTO>> GetCharacterById(int id)
        {
            var serviceResponse = new ServiceResponse<GetCharacterDTO>();
            var character = characters.FirstOrDefault(c => c.Id == id);

            serviceResponse.Data = _mapper.Map<GetCharacterDTO>(character);

            return serviceResponse;
            //return characters.FirstOrDefault(c => c.Id == id);
        }
    }
}