﻿using Microsoft.EntityFrameworkCore;

namespace ASP_GameStore.Api.Data;

public static class DataExtensions {
  public static async Task MigrateDBAsync(this WebApplication app) {
    using var scope = app.Services.CreateScope();
    var dbContext = scope.ServiceProvider.GetRequiredService<GameStoreContext>();
    await dbContext.Database.MigrateAsync();
  }
}