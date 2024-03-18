using GameShop.API.Entities;
using Microsoft.EntityFrameworkCore;

namespace GameShop.API.Data;

public class GameShopContext(DbContextOptions<GameShopContext> options) : DbContext(options)
{
    public DbSet<Game> Games => Set<Game>();
    public DbSet<Genre> Genres => Set<Genre>();
}
