using kol2.Models;

namespace kol2.Data;

using Microsoft.EntityFrameworkCore;


public class DatabaseContext : DbContext
{

    protected DatabaseContext()
    {
    }

    public DatabaseContext(DbContextOptions<DatabaseContext> options) : base(options)
    {
    }

    public DbSet<Item> Items { get; set; }
    public DbSet<Character> Characters { get; set; }
    public DbSet<Backpack> Backpacks { get; set; }
    public DbSet<Title> Titles { get; set; }
    public DbSet<CharacterTitle> CharacterTitles { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<Item>().HasData(new List<Item>
        {
            new Item
            {
                Id = 1,
                Name = "item",
                Weight = 2
            }
        });

        modelBuilder.Entity<Character>().HasData(new List<Character>
        {
            new Character
            {
                Id = 1,
                FirstName = "name",
                LastName = "lastname",
                CurrentWeight = 2,
                MaxWeight = 10
            }
        });

        modelBuilder.Entity<Backpack>().HasData(new List<Backpack>
        {
            new Backpack
            {
                CharacterId = 1,
                ItemId = 1,
                Amount = 2
            }
        });

        modelBuilder.Entity<Title>().HasData(new List<Title>
        {
            new Title
            {
                Id = 1,
                Name = "title",
            }
        });

        modelBuilder.Entity<CharacterTitle>().HasData(new List<CharacterTitle>
        {
            new CharacterTitle
            {
                CharacterId = 1,
                TitleId = 1,
                AcquiredAt = DateTime.Parse("2024-05-28")
            }
        });

    }
}
