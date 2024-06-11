using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;

namespace kol2.Models;


[Table("Backpack")]
[PrimaryKey(nameof(ItemId), nameof(CharacterId))]
public class Backpack
{
    public int CharacterId { get; set; }
    public int ItemId { get; set; }
    public int Amount { get; set; }

    [ForeignKey(nameof(ItemId))] public Item Item { get; set; } = null!;
    [ForeignKey(nameof(CharacterId))] public Character Character { get; set; } = null!;
}