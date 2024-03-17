using GameShop.API.DTOs;

var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

List<GameDTO> gameList =
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

app.MapGet("/", () => "Hello World!");

app.MapGet("/api/games", () => gameList);

app.MapGet("/api/games/{id}", (int id) => gameList.Find(game => game.Id == id)).WithName("GetGame");

app.MapPost(
    "/api/games",
    (CreateGameDTO game) =>
    {
        GameDTO newGame = new(gameList.Count + 1, game.Name, game.Genre, game.Price, game.ReleaseDate);
        gameList.Add(newGame);
        return Results.CreatedAtRoute("GetGame", new { id = newGame.Id }, newGame);
    }
);

app.Run();
