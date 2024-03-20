using GameShop.API.Entities;
using Microsoft.EntityFrameworkCore;

namespace GameShop.API.Data;

public class GameShopContext(DbContextOptions<GameShopContext> options) : DbContext(options)
{
    public DbSet<Game> Games => Set<Game>();
    public DbSet<Genre> Genres => Set<Genre>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder
            .Entity<Genre>()
            .HasData(
                new Genre { Id = 1, Name = "Action" },
                new Genre { Id = 2, Name = "RPG" },
                new Genre { Id = 3, Name = "Strategy" },
                new Genre { Id = 4, Name = "First Person Shooter" },
                new Genre { Id = 5, Name = "Mech" },
                new Genre { Id = 6, Name = "Puzzle" },
                new Genre { Id = 7, Name = "Sports" },
                new Genre { Id = 8, Name = "Racing" },
                new Genre { Id = 9, Name = "Fighting" },
                new Genre { Id = 10, Name = "Arcade" },
                new Genre { Id = 11, Name = "Platformer" },
                new Genre { Id = 12, Name = "Adventure" },
                new Genre { Id = 13, Name = "MMO" },
                new Genre { Id = 14, Name = "RTS" },
                new Genre { Id = 15, Name = "CRPG" },
                new Genre { Id = 16, Name = "Horror" },
                new Genre { Id = 17, Name = "MOBA" },
                new Genre { Id = 18, Name = "Card Game" },
                new Genre { Id = 19, Name = "Simulation" },
                new Genre { Id = 20, Name = "Third Person Shooter" }
            );
    }
}
