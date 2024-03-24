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
                async (GameShopContext dbContext) =>
                {
                    return await dbContext
                        .Games.Include(game => game.Genre)
                        .Select(game => game.ToGameSummaryDTO())
                        .AsNoTracking()
                        .ToListAsync();
                }
            )
            .WithName("GetGames");

        group
            .MapGet(
                "/{id}",
                async (int id, GameShopContext dbContext) =>
                {
                    Game? gameResult = await dbContext.Games.FindAsync(id);

                    return gameResult is not null
                        ? Results.Ok(gameResult.ToGameDetailsDTO())
                        : Results.NotFound();
                }
            )
            .WithName("GetGame");

        group
            .MapPost(
                "/",
                async (CreateGameDTO game, GameShopContext dbContext) =>
                {
                    Game newGame = game.ToEntity();

                    await dbContext.Games.AddAsync(newGame);
                    await dbContext.SaveChangesAsync();

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
                async (int id, UpdateGameDTO game, GameShopContext dbContext) =>
                {
                    var existingGame = await dbContext.Games.FindAsync(id);

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
            async (int id, GameShopContext dbContext) =>
            {
                await dbContext.Games.Where(game => game.Id == id).ExecuteDeleteAsync();

                return Results.NoContent();
            }
        );

        return group;
    }
}
