namespace Dotnet_Api_test.Dtos;

public record class GameDto
(
    int Id, string Name, string Genre, decimal Price, DateOnly ReleaseDate
);