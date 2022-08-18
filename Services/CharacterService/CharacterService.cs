﻿using _NET_RPG.DTOs.Character;
using _NET_RPG.Models;
using AutoMapper;

namespace _NET_RPG.Services.CharacterService
{
    public class CharacterService : ICharacterService
    {
        private static List<Character> characters = new List<Character> {
            new Character(),
            new Character { Id = 1, Name = "Sam" },
        };

        private readonly IMapper _mapper;

        public CharacterService(IMapper mapper)
        {
            _mapper = mapper;
        }

        public async Task<ServiceResponse<List<GetCharacterDTO>>> AddCharacter(AddCharacterDTO newCharacter)
        {
            var ServiceResponse = new ServiceResponse<List<GetCharacterDTO>>();
            Character character = _mapper.Map<Character>(newCharacter);
            character.Id = characters.Max(c => c.Id) + 1;
            characters.Add(character);
            ServiceResponse.Data = characters.Select(c => _mapper.Map<GetCharacterDTO>(c)).ToList();
            return ServiceResponse;
        }

        public async Task<ServiceResponse<List<GetCharacterDTO>>> DeleteCharacter(int id)
        {
            ServiceResponse<List<GetCharacterDTO>> response = new ServiceResponse<List<GetCharacterDTO>>();

            try
            {
                Character character = characters.First(c => c.Id == id);
                characters.Remove(character);
                response.Data = characters.Select(c => _mapper.Map<GetCharacterDTO>(c)).ToList();
            }
            catch (Exception ex)
            {
                response.Success = false;
                response.Message = ex.Message;
            }

            return response;

        }

        public async Task<ServiceResponse<List<GetCharacterDTO>>> GetAllCharacters()
        {
            return new ServiceResponse<List<GetCharacterDTO>> { Data = characters
                .Select(c => _mapper.Map<GetCharacterDTO>(c)).ToList()};
        }

        public async Task<ServiceResponse<GetCharacterDTO>> GetCharacterById(int id)
        {
            var serviceResponse = new ServiceResponse<GetCharacterDTO>();
            var character = characters.FirstOrDefault(c => c.Id == id);
            serviceResponse.Data = _mapper.Map<GetCharacterDTO>(character);
            return serviceResponse;
        }

        public async Task<ServiceResponse<GetCharacterDTO>> UpdateCharacter(UpdateCharacterDTO updatedCharacter)
        {
            ServiceResponse<GetCharacterDTO> response = new ServiceResponse<GetCharacterDTO>();

            try
            {
                Character character = characters.FirstOrDefault(c => c.Id == updatedCharacter.Id);

                _mapper.Map(updatedCharacter, character);
                //character.Name = updatedCharacter.Name;
                //character.HitPoints = updatedCharacter.HitPoints;
                //character.Strength = updatedCharacter.Strength;
                //character.Defense = updatedCharacter.Defense;
                //character.Class = updatedCharacter.Class;

                response.Data = _mapper.Map<GetCharacterDTO>(character);
            }
            catch (Exception ex)
            {
                response.Success = false;
                response.Message = ex.Message;
            }

            return response;


        }
    }
}
