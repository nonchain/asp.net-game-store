using ASP_GameStore.Api.Dtos;
using ASP_GameStore.Api.Entities;

namespace ASP_GameStore.Api.Mapping;

public static class GenreMapping {
  public static GenreDto ToDto(this Genre genre) {
    return new GenreDto(genre.Id, genre.Name);
  }
}