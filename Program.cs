using Microsoft.Data.Sqlite;
using System.Data;
using ProjetoLoja.Repository;

var builder = WebApplication.CreateBuilder(args);

builder.Configuration.AddJsonFile("appsettings.json");

string connectionString = builder.Configuration.GetConnectionString("DefaultConnection");

builder.Services.AddTransient<IDbConnection>((sp) => new SqliteConnection(connectionString));
builder.Services.AddTransient<DapperRepository>();

builder.Services.AddControllers();

var app = builder.Build();

app.MapControllers();

app.Run();


