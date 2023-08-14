using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using rpc.DTOs.Character;
using rpc.Models;

namespace rpc.Services.CharacterService
{
    public interface ICharacterService
    {
        // refactored to use ServiceResponse, which is a generic class
        Task<ServiceResponse<List<GetCharacterDTO>>> GetAllCharacters();
        Task<ServiceResponse<GetCharacterDTO>> GetCharacterById(int id);
        Task<ServiceResponse<List<GetCharacterDTO>>> AddCharacter(AddCharacterDTO newCharacter);
    }
}