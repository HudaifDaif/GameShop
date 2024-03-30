using GameShop.Frontend.Models;

namespace GameShop.Frontend;

public static class GameClient
{
    private static readonly List<Game> games =
        new()
        {
            new Game()
            {
                Id = 1,
                Name = "The Last of Us",
                Genre = "Action",
                Price = 29.99M,
                ReleaseDate = new DateOnly(2013, 6, 14)
            },
            new Game()
            {
                Id = 2,
                Name = "Hollow Knight",
                Genre = "Adventure",
                Price = 9.99M,
                ReleaseDate = new DateOnly(2017, 2, 24)
            },
            new Game()
            {
                Id = 3,
                Name = "Prey",
                Genre = "First Person Shooter",
                Price = 10.49M,
                ReleaseDate = new DateOnly(2017, 4, 27)
            },
            new Game()
            {
                Id = 4,
                Name = "The Witcher 3: Wild Hunt",
                Genre = "RPG",
                Price = 19.99M,
                ReleaseDate = new DateOnly(2015, 5, 18)
            }
        };

    public static Game[] GetGames() => games.ToArray();

    public static void AddGame(Game game)
    {
        game.Id = games.Max(g => g.Id) + 1;
        games.Add(game);
    }

    public static Game GetGame(int id)
    {
        return games.Find(g => g.Id == id) ?? throw new Exception("Game not found");
    }

    public static void UpdateGame(Game updatedGame)
    {
        Game existingGame = GetGame(updatedGame.Id);
        existingGame.Name = updatedGame.Name;
        existingGame.Genre = updatedGame.Genre;
        existingGame.Price = updatedGame.Price;
        existingGame.ReleaseDate = updatedGame.ReleaseDate;
    }

    public static void DeleteGame(int id)
    {
        Game game = GetGame(id);
        games.Remove(game);
    }
}
