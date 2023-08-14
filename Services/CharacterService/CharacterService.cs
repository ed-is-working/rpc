global using AutoMapper;

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
            new Character { Id = 2, Name = "Sam" }
        };
        private readonly IMapper _mapper;

        public CharacterService(IMapper mapper)
        {
            _mapper = mapper;
        }
        /* TODO: when DB is implemented, update this to use DB with await calls */
        public async Task<ServiceResponse<List<GetCharacterDTO>>> AddCharacter(AddCharacterDTO newCharacter)
        {
            // add serviceResponse to every method and set the data property accordingly
            var serviceResponse = new ServiceResponse<List<GetCharacterDTO>>();
            // create a new character
            var character = _mapper.Map<Character>(newCharacter);
            // set the Id to the next available Id
            character.Id = characters.Max(c => c.Id) + 1;

            // TODO: add validation, ensure that a character with the same name / Id does not already exist
            characters.Add(character);
            // use the Select() method to map each character to a GetCharacterDTO
            // then convert it to a List.  This is a LINQ method that is similar to a foreach loop
            serviceResponse.Data = characters.Select(c => _mapper.Map<GetCharacterDTO>(c)).ToList();  // set the data property to the list of characters

            return serviceResponse;
        }

        public async Task<ServiceResponse<List<GetCharacterDTO>>> GetAllCharacters()
        {
            // add serviceResponse to every method and set the data property accordingly
            var serviceResponse = new ServiceResponse<List<GetCharacterDTO>>();
            // use the Select() method to map each character to a GetCharacterDTO
            // then convert it to a List.  This is a LINQ method that is similar to a foreach loop
            serviceResponse.Data = characters.Select(c => _mapper.Map<GetCharacterDTO>(c)).ToList();  // set the data property to the list of characters

            return serviceResponse;
        }

        public async Task<ServiceResponse<GetCharacterDTO>> GetCharacterById(int id)
        {
            // null check is now removed since data is nullable, will return null
            var serviceResponse = new ServiceResponse<GetCharacterDTO>();
            // set character to the character with the matching id
            var character = characters.FirstOrDefault(c => c.Id == id);
            serviceResponse.Data = _mapper.Map<GetCharacterDTO>(character);  // set the data property to the list of characters 

            return serviceResponse;
        }

        public async Task<ServiceResponse<GetCharacterDTO>> UpdateCharacter(UpdateCharacterDTO updatedCharacter)
        {
            // update all the properties with new values
            var serviceResponse = new ServiceResponse<GetCharacterDTO>();

            try
            {
                // set character to the character with the matching id
                var character = characters.FirstOrDefault(c => c.Id == updatedCharacter.Id);
                if (character is null)
                {
                    //serviceResponse.Success = false;
                    //serviceResponse.Message = "Character not found.";
                    //return serviceResponse; // or throw an exception

                    throw new Exception($"Character with id {updatedCharacter.Id} not found.");
                }

                // options: use automapper to map the updatedCharacter to the character
                // _mapper.Map<Character>(updatedCharacter); // or
                // _mapper.Map(updatedCharacter, character); // but would have to update AutoMapperProfile.cs

                // update the character with the new values
                character.Name = updatedCharacter.Name;
                character.EMail = updatedCharacter.EMail;
                character.Class = updatedCharacter.Class;
                character.Defense = updatedCharacter.Defense;
                character.HitPoints = updatedCharacter.HitPoints;
                character.Intelligence = updatedCharacter.Intelligence;
                character.Strength = updatedCharacter.Strength;
                serviceResponse.Data = _mapper.Map<GetCharacterDTO>(character);

            }
            catch (Exception ex)
            {
                serviceResponse.Success = false;
                serviceResponse.Message = ex.Message;
            }

            return serviceResponse;

        }

        public Task<ServiceResponse<List<GetCharacterDTO>>> DeleteCharacter(int id)
        {
            var serviceResponse = new ServiceResponse<List<GetCharacterDTO>>();
            try
            {
                var character = characters.First(c => c.Id == id);
                if (character is null)
                {
                    throw new Exception($"Character with Id '{id}' not found");
                }
                characters.Remove(character);
                serviceResponse.Data = characters.Select(c => _mapper.Map<GetCharacterDTO>(c)).ToList();
            }
            catch (Exception ex)
            {
                serviceResponse.Success = false;
                serviceResponse.Message = ex.Message;
            }

            // return serviceResponse;

            throw new NotImplementedException();
        }

    }
}