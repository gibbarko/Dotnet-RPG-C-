using _NET_RPG.DTOs.Character;

namespace _NET_RPG.Services.CharacterService
{
    public interface ICharacterService
    {
        Task<ServiceResponse<List<GetCharacterDTO>>> GetAllCharacters();
        Task<ServiceResponse<GetCharacterDTO>> GetCharacterById(int id);
        Task<ServiceResponse<List<GetCharacterDTO>>> AddCharacter(AddCharacterDTO newCharacter);
        Task<ServiceResponse<GetCharacterDTO>> UpdateCharacter(UpdateCharacterDTO updatedCharacterDTO);
        Task<ServiceResponse<List<GetCharacterDTO>>> DeleteCharacter(int id);
    }
}
