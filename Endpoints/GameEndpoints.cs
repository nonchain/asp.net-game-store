using ASP_GameStore.Api.Data;
using ASP_GameStore.Api.Dtos;
using ASP_GameStore.Api.Entities;
using ASP_GameStore.Api.Mapping;
using Microsoft.EntityFrameworkCore;

namespace ASP_GameStore.Api.Endpoints;

public static class GameEndpoints {
  const string GET_GAME_ENDPOINT_NAME = "games";

  public static RouteGroupBuilder MakeGameEndpoints(this WebApplication app) {
    var group = app.MapGroup("games").WithParameterValidation();
    // GET /games
    group.MapGet("/", async (GameStoreContext dbContext) => {
      var games = await dbContext.Games.Include(game => game.Genre)
        .Select(game => game.ToDto())
        .AsSingleQuery()
        .ToListAsync();

      return games;
    });

    // GET games/id
    group.MapGet(
        "/{id}",
        async (int id, GameStoreContext dbContext) => {
          Game game = await dbContext.Games.FindAsync(id);
          if (game == null) return Results.NotFound();

          game.Genre = await dbContext.Genres.FindAsync(game.GenreId);

          return Results.Ok(game);
        }
      )
      .WithName(GET_GAME_ENDPOINT_NAME);

    // POST games
    group.MapPost(
      "/",
      async (CreateGameDto newGame, GameStoreContext dbContext) => {
        Game game = newGame.ToEntity();
        game.Genre = await dbContext.Genres.FindAsync(newGame.GenreId);

        dbContext.Games.Add(game);
        await dbContext.SaveChangesAsync();

        return Results.CreatedAtRoute(GET_GAME_ENDPOINT_NAME, new { id = game.Id }, game.ToDto());
      }
    );

    // PUT games/id
    group.MapPut(
      "/{id}",
      async (int id, UpdateGameDto updateGame, GameStoreContext dbContext) => {
        var selectedGame = await dbContext.Games.FindAsync(id);
        if (selectedGame == null) return Results.NotFound();

        dbContext.Entry(selectedGame)
          .CurrentValues
          .SetValues(updateGame.ToEntity(id));

        await dbContext.SaveChangesAsync();
        return Results.NoContent();
      }
    );

    // DELETE games/id
    group.MapDelete(
      "/{id}",
      async (int id, GameStoreContext dbContext) => {
        await dbContext.Games.Where(game => game.Id == id)
          .ExecuteDeleteAsync();

        return Results.NoContent();
      }
    );

    return group;
  }
}