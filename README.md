# Simple API with ASP.NET

Welcome to the **My Gamestore API with ASP.NET** project! This API is designed to provide basic CRUD (Create, Read, Update, Delete) operations for games and a read-only access for genres.

## Endpoints

### /games
This endpoint allows users to perform CRUD operations on games.
- **GET /games**: Retrieve a list of all games.
- **GET /games/{id}**: Retrieve a specific game by its ID.
- **POST /games**: Create a new game.
- **PUT /games/{id}**: Update an existing game by its ID.
- **DELETE /games/{id}**: Delete a game by its ID.

### /genres
This endpoint allows users to read genres.
- **GET /genres**: Retrieve a list of all genres.
- **GET /genres/{id}**: Retrieve a specific genre by its ID.

## Database

The project uses SQLite as its database, managed through the Entity Framework Core (Microsoft.EntityFrameworkCore.SQLite). The ORM (Object-Relational Mapping) concept is utilized for seamless interaction between the application and the database.

## Getting Started

### Prerequisites

- [.NET 8.0 SDK](https://dotnet.microsoft.com/download/dotnet/8.0)
- [SQLite](https://www.sqlite.org/download.html)

### Installation

1. Clone the repository:
   ```sh
   git clone git@github.com:nonchain/asp.net-game-store.git
   ```
2. Navigate to the project directory:
   ```sh
   cd /asp.net-game-store
   ```
3. Restore the dependencies:
   ```sh
   dotnet restore
   ```
4. Update the database:
   ```sh
   dotnet ef database update
   ```

### Running the API

Start the API by running:
```sh
dotnet run
```

The API will be available at `https://localhost:5001`.

## Usage

You can use tools like [Postman](https://www.postman.com/) or [curl](https://curl.se/) to interact with the API endpoints.

## Contributing

Contributions are welcome! Please open an issue or submit a pull request for any improvements or bug fixes.

## License

This project is licensed under the MIT License - see the [LICENSE](LICENSE) file for details.

## Acknowledgments

- [ASP.NET Core](https://docs.microsoft.com/en-us/aspnet/core/?view=aspnetcore-6.0)
- [Entity Framework Core](https://docs.microsoft.com/en-us/ef/core/)
- [SQLite](https://www.sqlite.org/index.html)

---

Thank you for checking out this project! If you have any questions or need further assistance, feel free to open an issue in the repository.
