using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using dotnet_rpg.DTO.Character;
using dotnet_rpg.Models;

namespace dotnet_rpg
{
    public class AutoMapper : Profile
    {
        public AutoMapper()
        {
            CreateMap<Character, GetCharacterDTO>();
            CreateMap<AddCharacterDTO, Character>();
        }
    }
}