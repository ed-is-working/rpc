using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using rpc.Models;

namespace rpc.Services.CharacterService
{
    public interface ICharacterService
    {
        List<Character> GetAllCharacters();
        Character GetCharacterById(int id);
        List<Character> AddCharacter(Character newCharacter);
    }
}