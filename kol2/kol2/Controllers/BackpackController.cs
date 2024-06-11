using kol2.Data;
using kol2.Models;
using kol2.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace kol2.Controllers;

[ApiController]
[Route("api/characters/{characterId}/backpacks")]
public class BackpackController : ControllerBase
{
    private readonly IDbService _dbService;
    private readonly DatabaseContext _context;
 
    public BackpackController(IDbService dbService, DatabaseContext context)
    {
        _dbService = dbService;
        _context = context;
    }
 
    [HttpPost]
    public async Task<IActionResult> AddItemsToBackpack(int characterId, [FromBody] int[] itemIds)
    {
        var items = await _context.Items
            .Where(i => itemIds.Contains(i.Id))
            .ToListAsync();
 
        if (items.Count != itemIds.Length)
        {
            return BadRequest("One or more items do not exist.");
        }
 
        var character = await _dbService.GetCharacterById(characterId);
        if (character == null)
        {
            return NotFound("Character not found.");
        }
 
        int currentWeight = character.Backpacks.Sum(bi => bi.Item.Weight * bi.Amount);
        int additionalWeight = items.Sum(i => i.Weight);
        if (currentWeight + additionalWeight > character.MaxWeight)
        {
            return BadRequest("Adding these items would exceed the character's carrying capacity.");
        }
 
        var success = await _dbService.AddItemsToBackpack(characterId, items.Select(i => new Backpack
        {
            CharacterId = characterId,
            ItemId = i.Id,
            Amount = 1
        }));
 
        if (!success)
        {
            return BadRequest("Failed to add items to backpack.");
        }
 
        return Ok(items.Select(i => new { itemId = i.Id, characterId = characterId, amount = 1 }));
    }
}