using System.ComponentModel.DataAnnotations;

namespace ASP_GameStore.Api.Dtos;

public record class UpdateGameDto(
  [Required] [StringLength(50)] string Name,
  [Required] int GenreId,
  [Required] [Range(1, 100)] decimal Price,
  DateOnly ReleaseDate);