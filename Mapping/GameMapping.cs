using ASP_GameStore.Api.Dtos;
using ASP_GameStore.Api.Entities;

namespace ASP_GameStore.Api.Mapping;

public static class GameMapping {
  public static Game ToEntity(this CreateGameDto game) {
    return new Game() {
      Name = game.Name,
      GenreId = game.GenreId,
      Price = game.Price,
      ReleaseDate = game.ReleaseDate
    };
  }
  public static Game ToEntity(this UpdateGameDto game, int id) {
    return new Game() {
      Id = id,
      Name = game.Name,
      GenreId = game.GenreId,
      Price = game.Price,
      ReleaseDate = game.ReleaseDate
    };
  }

  public static GameDto ToDto(this Game game) {
     return new GameDto(
      game.Id,
      game.Name,
      game.Genre.Name,
      game.Price,
      game.ReleaseDate
    );
  }
  
  public static GameSummeryDto ToSummeryDto(this Game game) {
    return new GameSummeryDto(
      game.Id,
      game.Name,
      game.GenreId,
      game.Price,
      game.ReleaseDate
    );
  }
}