using ASP_GameStore.Api.Entities;
using Microsoft.EntityFrameworkCore;

namespace ASP_GameStore.Api.Data;

public class GameStoreContext(DbContextOptions<GameStoreContext> options) : DbContext(options) {
  public DbSet<Game> Games => Set<Game>();
  public DbSet<Genre> Genres => Set<Genre>();

  protected override void OnModelCreating(ModelBuilder modelBuilder) {
    modelBuilder.Entity<Genre>().HasData(
      new {Id = 1, Name = "Sports"},
      new {Id = 2, Name = "Family"},
      new {Id = 3, Name = "Racing"},
      new {Id = 4, Name = "Action"},
      new {Id = 5, Name = "Educations"}
    );
  }
}