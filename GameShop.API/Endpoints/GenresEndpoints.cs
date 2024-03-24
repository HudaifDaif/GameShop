using GameShop.API.Data;
using GameShop.API.Mapping;
using Microsoft.EntityFrameworkCore;

namespace GameShop.API.Endpoints;

public static class GenresEndpoints
{
    public static RouteGroupBuilder MapGenreEndpoints(this WebApplication app)
    {
        RouteGroupBuilder group = app.MapGroup("/api/genres");

        group.MapGet(
            "/",
            async (GameShopContext dbContext) =>
            {
                return await dbContext
                    .Genres.Select(genre => genre.ToGenreDTO())
                    .AsNoTracking()
                    .ToListAsync();
            }
        );

        return group;
    }
}
