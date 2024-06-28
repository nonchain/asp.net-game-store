namespace ASP_GameStore.Api.Dtos;

public record class GameSummeryDto(int Id, string Name, int GenreId, decimal Price, DateOnly ReleaseDate);