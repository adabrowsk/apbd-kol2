using kol2.Services;
using Microsoft.AspNetCore.Mvc;

namespace kol2.Controllers;

[ApiController]
[Route("api/characters")]
public class CharactersController : ControllerBase
{
    private readonly IDbService _dbService;
 
    public CharactersController(IDbService dbService)
    {
        _dbService = dbService;
    }
 
    [HttpGet("{characterId}")]
    public async Task<IActionResult> GetCharacterById(int characterId)
    {
        var character = await _dbService.GetCharacterById(characterId);
        if (character == null)
        {
            return NotFound();
        }
        
        int currentWeight = character.Backpacks.Sum(item => item.Item.Weight * item.Amount);
 
        var result = new
        {
            firstName = character.FirstName,
            lastName = character.LastName,
            currentWeight = currentWeight,
            maxWeight = character.MaxWeight,
            backpackItems = character.Backpacks.Select(bi => new
            {
                itemName = bi.Item.Name,
                itemWeight = bi.Item.Weight,
                amount = bi.Amount
            }),
            titles = character.CharacterTitles.Select(ct => new
            {
                title = ct.Item.Name,
                acquiredAt = ct.AcquiredAt
            })
        };
 
        return Ok(result);
    }
}