﻿using GameShop.API.DTOs;

namespace GameShop.API.Endpoints;

public static class GamesEndpoints
{
    private static List<GameDTO> gameList =
    [
        new(
            Id: 1,
            Name: "Elden Ring",
            Genre: "RPG",
            Price: 59.99m,
            ReleaseDate: new DateOnly(2022, 2, 25)
        ),
        new(
            Id: 2,
            Name: "Helldivers 2",
            Genre: "Third Person Shooter",
            Price: 34.99m,
            ReleaseDate: new DateOnly(2024, 2, 8)
        ),
        new(
            Id: 3,
            Name: "Armored Core VI: Fires of Rubicon",
            Genre: "Mech Madness",
            Price: 44.99m,
            ReleaseDate: new DateOnly(2023, 8, 24)
        ),
        new(
            Id: 4,
            Name: "Cuphead",
            Genre: "Platformer",
            Price: 19.99m,
            ReleaseDate: new DateOnly(2017, 9, 29)
        ),
        new(
            Id: 5,
            Name: "Dragon's Dogma 2",
            Genre: "RPG",
            Price: 69.99m,
            ReleaseDate: new DateOnly(2024, 3, 22)
        ),
        new(
            Id: 6,
            Name: "Palworld",
            Genre: "Action Adventure",
            Price: 29.99m,
            ReleaseDate: new DateOnly(2024, 1, 19)
        )
    ];

    public static RouteGroupBuilder MapGamesEndpoints(this WebApplication app)
    {
        RouteGroupBuilder group = app.MapGroup("/api/games");

        group.MapGet("/", () => gameList);

        group
            .MapGet(
                "/{id}",
                (int id) =>
                {
                    GameDTO? gameResult = gameList.Find(game => game.Id == id);

                    return gameResult is not null ? Results.Ok(gameResult) : Results.NotFound();
                }
            )
            .WithName("GetGame");

        group.MapPost(
            "/",
            (CreateGameDTO game) =>
            {
                GameDTO newGame =
                    new(gameList.Count + 1, game.Name, game.Genre, game.Price, game.ReleaseDate);
                gameList.Add(newGame);
                return Results.CreatedAtRoute("GetGame", new { id = newGame.Id }, newGame);
            }
        );

        group.MapPut(
            "/{id}",
            (int id, UpdateGameDTO game) =>
            {
                int index = gameList.FindIndex(game => game.Id == id);

                if (index == -1)
                {
                    return Results.NotFound();
                }

                gameList[index] = new GameDTO(
                    id,
                    game.Name,
                    game.Genre,
                    game.Price,
                    game.ReleaseDate
                );

                return Results.NoContent();
            }
        );

        group.MapDelete(
            "/{id}",
            (int id) =>
            {
                gameList.RemoveAll(game => game.Id == id);
                return Results.NoContent();
            }
        );

        return group;
    }
}