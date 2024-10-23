namespace Dotnet_Api_test.Dtos;

public record class CreateGameDto
(
    string Name,
    string Genre,
    decimal Price,
    DateOnly RelaseDate
);