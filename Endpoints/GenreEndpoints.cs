using ASP_GameStore.Api.Data;
using ASP_GameStore.Api.Mapping;
using Microsoft.EntityFrameworkCore;

namespace ASP_GameStore.Api.Endpoints;

public static class GenreEndpoints {
  const string GET_GENRE_ENDPOINT_NAME = "genres";

  public static RouteGroupBuilder MakeGenreEndpoints(this WebApplication app) {
    var group = app.MapGroup("genres").WithParameterValidation();

    group.MapGet("/", async (GameStoreContext dbContext) => {
      var genres = await dbContext.Genres.Select(genre => genre.ToDto()).AsNoTracking().ToListAsync();

      return genres;
    });
    
    group.MapGet("/{id}", async (int id, GameStoreContext dbContext) => {
      var genre = await dbContext.Genres.FindAsync(id);
      
      return genre.ToDto();
    });

    return group;
  }
}