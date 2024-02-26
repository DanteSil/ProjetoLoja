using Microsoft.Data.Sqlite;
using System.Data;
using ProjetoLoja.Repository;
using ProjetoLoja.DataBase.MyDbContext;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

IConfiguration configuration = new ConfigurationBuilder()
    .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
    .Build();

builder.Configuration.AddJsonFile("appsettings.json");

string connectionString = builder.Configuration.GetConnectionString("DefaultConnection");

builder.Services.AddDbContext<MyDbContext>(options => options.UseSqlite(connectionString));

builder.Services.AddControllers();

var app = builder.Build();

app.MapControllers();

app.Run();


