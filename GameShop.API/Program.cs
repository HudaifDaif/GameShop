using GameShop.API.Data;
using GameShop.API.Endpoints;

var builder = WebApplication.CreateBuilder(args);

string? connectionString = builder.Configuration.GetConnectionString("GameShopDB");
builder.Services.AddSqlite<GameShopContext>(connectionString);

var app = builder.Build();

app.MapGet("/", () => "Hello World!");

app.MapGamesEndpoints();

app.MapGenreEndpoints();

await app.MigrateDbAsync();

app.Run();
