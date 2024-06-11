namespace kol2.DTOs;

public class GetCharacterDTO
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public int CurrentWeight { get; set; }
    public int MaxWeight { get; set; }
    public ICollection<GetBackpackDTO> Backpacks { get; set; } = null!;
}

public class GetBackpackDTO
{
    public string ItemName { get; set; }
    public int ItemWeight { get; set; }
    public int amount { get; set; }
}