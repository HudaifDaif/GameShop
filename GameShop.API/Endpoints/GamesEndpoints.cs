using GameShop.API.Data;
using GameShop.API.DTOs;
using GameShop.API.Entities;
using GameShop.API.Mapping;
using Microsoft.EntityFrameworkCore;

namespace GameShop.API.Endpoints;

public static class GamesEndpoints
{
    public static RouteGroupBuilder MapGamesEndpoints(this WebApplication app)
    {
        RouteGroupBuilder group = app.MapGroup("/api/games");

        group
            .MapGet(
                "/",
                (GameShopContext dbContext) =>
                {
                    return dbContext
                        .Games.Include(game => game.Genre)
                        .Select(game => game.ToGameSummaryDTO())
                        .AsNoTracking();
                }
            )
            .WithName("GetGames");

        group
            .MapGet(
                "/{id}",
                (int id, GameShopContext dbContext) =>
                {
                    Game? gameResult = dbContext.Games.Find(id);

                    return gameResult is not null
                        ? Results.Ok(gameResult.ToGameDetailsDTO())
                        : Results.NotFound();
                }
            )
            .WithName("GetGame");

        group
            .MapPost(
                "/",
                (CreateGameDTO game, GameShopContext dbContext) =>
                {
                    Game newGame = game.ToEntity();

                    dbContext.Games.Add(newGame);
                    dbContext.SaveChanges();

                    return Results.CreatedAtRoute(
                        "GetGame",
                        new { id = newGame.Id },
                        newGame.ToGameDetailsDTO()
                    );
                }
            )
            .WithParameterValidation();

        group
            .MapPut(
                "/{id}",
                (int id, UpdateGameDTO game, GameShopContext dbContext) =>
                {
                    var existingGame = dbContext.Games.Find(id);

                    if (existingGame is null)
                    {
                        return Results.NotFound();
                    }

                    dbContext.Entry(existingGame).CurrentValues.SetValues(game.ToEntity(id));
                    dbContext.SaveChanges();

                    return Results.NoContent();
                }
            )
            .WithParameterValidation();

        group.MapDelete(
            "/{id}",
            (int id, GameShopContext dbContext) =>
            {
                dbContext.Games.Where(game => game.Id == id).ExecuteDelete();

                return Results.NoContent();
            }
        );

        return group;
    }
}
