using GameShop.API.DTOs;
using GameShop.API.Entities;

namespace GameShop.API.Mapping;

public static class GameMapping
{
    public static Game ToEntity(this CreateGameDTO game)
    {
        return new Game()
        {
            Name = game.Name,
            GenreId = game.GenreId,
            Price = game.Price,
            ReleaseDate = game.ReleaseDate
        };
    }

    public static GameDTO ToDTO(this Game game)
    {
        return new GameDTO(game.Id, game.Name, game.Genre!.Name, game.Price, game.ReleaseDate);
    }
}
