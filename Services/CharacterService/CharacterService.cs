using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using rpc.Models;

namespace rpc.Services.CharacterService
{
    public class CharacterService : ICharacterService
    {
        // enable list of characters
        private static List<Character> characters = new List<Character>
        {
            new Character(),
            new Character { Id = 1, Name = "Sam" }
        };
        public List<Character> AddCharacter(Character newCharacter)
        {

            // TODO: add validation, ensure that a character with the same name / Id does not already exist
            characters.Add(newCharacter);
            return characters;
        }

        public List<Character> GetAllCharacters()
        {
            // can also implement BadRequest or NotFound
            return characters;
        }

        public Character GetCharacterById(int id)
        {
            var character = characters.FirstOrDefault(c => c.Id == id);

            // can also implement BadRequest or NotFound
            return (character is not null) ? character : throw new Exception("Character not found");
        }

    }
}