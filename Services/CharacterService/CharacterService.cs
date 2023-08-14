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

        /* TODO: when DB is implemented, update this to use DB with await calls */
        public async Task<ServiceResponse<List<GetCharacterDTO>>> AddCharacter(AddCharacterDTO newCharacter)
        {
            // add serviceResponse to every method and set the data property accordingly
            var serviceResponse = new ServiceResponse<List<GetCharacterDTO>>();

            // TODO: add validation, ensure that a character with the same name / Id does not already exist
            characters.Add(newCharacter);
            serviceResponse.Data = characters;  // set the data property to the list of characters
            return serviceResponse;
        }

        public async Task<ServiceResponse<List<GetCharacterDTO>>> GetAllCharacters()
        {
            // add serviceResponse to every method and set the data property accordingly
            var serviceResponse = new ServiceResponse<List<GetCharacterDTO>>();
            serviceResponse.Data = characters;  // set the data property to the list of characters

            // can also implement BadRequest or NotFound
            return serviceResponse;
        }

        public async Task<ServiceResponse<GetCharacterDTO>> GetCharacterById(int id)
        {
            var character = characters.FirstOrDefault(c => c.Id == id);

            // can also implement BadRequest or NotFound
            // null check is now removed since data is nullable, will return null
            var serviceResponse = new ServiceResponse<GetCharacterDTO>();
            // set character to the character with the matching id
            character = characters.FirstOrDefault(c => c.Id == id); 
            serviceResponse.Data = character;
            return serviceResponse;
        }

        Task<ServiceResponse<GetCharacterDTO>> ICharacterService.GetCharacterById(int id)
        {
            throw new NotImplementedException();
        }
    }
}