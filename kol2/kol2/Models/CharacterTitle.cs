using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace kol2.Models;


[Table("CharacterTitle")]
[PrimaryKey(nameof(TitleId), nameof(CharacterId))]
public class CharacterTitle
{
    public int CharacterId { get; set; }
    public int TitleId { get; set; }
    public DateTime AcquiredAt { get; set; }

    [ForeignKey(nameof(TitleId))] public Item Item { get; set; } = null!;
    [ForeignKey(nameof(CharacterId))] public Character Character { get; set; } = null!;
}