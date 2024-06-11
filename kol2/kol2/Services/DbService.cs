using kol2.Data;
using kol2.Models;
using Microsoft.EntityFrameworkCore;

namespace kol2.Services;

public class DbService : IDbService
{
        private readonly DatabaseContext _context;
 
        public DbService(DatabaseContext context)
        {
            _context = context;
        }

 
        public async Task<Character> GetCharacterById(int characterId)
        {
            return await _context.Characters
                .Include(c => c.Backpacks)
                .Include(c => c.CharacterTitles)
                .FirstOrDefaultAsync(c => c.Id == characterId);
        }
 
        public async Task<bool> AddItemsToBackpack(int characterId, IEnumerable<Backpack> items)
        {
            var character = await _context.Characters
                .Include(c => c.Backpacks)
                .FirstOrDefaultAsync(c => c.Id == characterId);
 
            if (character == null)
                return false;
 
            foreach (var item in items)
            {
                var existingItem = character.Backpacks
                    .FirstOrDefault(bi => bi.ItemId == item.ItemId);
 
                if (existingItem != null)
                {
                    existingItem.Amount += item.Amount;
                }
                else
                {
                    character.Backpacks.Add(item);
                }
            }
 
            await _context.SaveChangesAsync();
            return true;
        }
    }
