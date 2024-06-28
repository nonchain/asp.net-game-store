using ASP_GameStore.Api.Data;
using ASP_GameStore.Api.Endpoints;

var builder = WebApplication.CreateBuilder(args);
var connString = builder.Configuration.GetConnectionString("GameStore");
builder.Services.AddSqlite<GameStoreContext>(connString);
var app = builder.Build();

app.MakeGameEndpoints();
app.MakeGenreEndpoints();
await app.MigrateDBAsync();
app.Run();