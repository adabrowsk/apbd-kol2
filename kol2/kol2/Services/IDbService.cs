using kol2.Models;

namespace kol2.Services;

public interface IDbService
{

    Task<Character> GetCharacterById(int characterId);
    Task<bool> AddItemsToBackpack(int characterId, IEnumerable<Backpack> items);

}