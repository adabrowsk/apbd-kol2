using System.ComponentModel.DataAnnotations;

namespace kol2.DTOs;

public class NewItemDTO
{
    [Required]
    public int Amount { get; set; }
    [Required]
    public int ItemId { get; set; }
    [Required]
    public int CharacterId { get; set; }
}