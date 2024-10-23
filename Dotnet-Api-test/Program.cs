using Dotnet_Api_test.Dtos;

var builder = WebApplication.CreateBuilder(args);

var app = builder.Build();
const string getGameEndPointName = "GetGame";

List<GameDto> games = [
    new GameDto(1, "Game 1", "Genre 1", 10.99m, new DateOnly(2022, 1, 1)),
    new GameDto(2, "Game 2", "Genre 2", 15.99m, new DateOnly(2022, 2, 1)),
    new GameDto(3, "Game 3", "Genre 3", 20.99m, new DateOnly(2022, 3, 1)),
    new GameDto(4, "Game 4", "Genre 4", 25.99m, new DateOnly(2022, 4, 1)),
    new GameDto(5, "Game 5", "Genre 5", 30.99m, new DateOnly(2022, 5, 1))
];

app.MapGet("/", () => "Hello MaMa");
app.MapGet("games", () => games);

app.MapGet("games/{id}", (int id) => games.Find(game => game.Id == id)).WithName(getGameEndPointName);
app.MapPost("games", (CreateGameDto newGame) =>
{
    GameDto game = new(games.Count + 1, newGame.Name, newGame.Genre, newGame.Price, newGame.RelaseDate);
    return Results.CreatedAtRoute(getGameEndPointName, new { id = game.Id }, game);
});
app.MapPut("/games/{id}", (int id, CreateGameDto updateGames) =>
{
    var index = games.FindIndex((game) => game.Id == id);
    games[index] = new(id, updateGames.Name, updateGames.Genre, updateGames.Price, updateGames.RelaseDate);
    return Results.NoContent();
});
app.MapDelete("/games/{id}", (int id) =>
{
    games.RemoveAll((game) => game.Id == id);
    return Results.NoContent();
});
app.Run();