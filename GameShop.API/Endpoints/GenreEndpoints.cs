namespace GameShop.API.Endpoints;

public static class GenreEndpoints
{
    public static RouteGroupBuilder MapGenreEndpoints(this WebApplication app)
    {
        RouteGroupBuilder group = app.MapGroup("/api/genres");

        return group;
    }
}
