using Infrastructure.Data;
using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;
using Domain.Interface;
using Application.Services;
using Application.Interfaces;
using static Domain.Interface.IRepositoryDirector;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//Configure the SQLite connecition
string connectionString = builder.Configuration["ConnectionStrings:cineBackEndDBConnectionString"]!;

var connection = new SqliteConnection(connectionString);
connection.Open();

// Set journal mode to DELETE using PRAGMA statement
using (var command = connection.CreateCommand())
{
    command.CommandText = "PRAGMA journal_mode = DELETE;";
    command.ExecuteNonQuery();
}

builder.Services.AddCors(options =>
{   //SpecificOrigins
    options.AddPolicy("AllowLocalhost",
        builder =>
        {
            builder.WithOrigins("http://localhost:5173", "http://localhost:5174", "http://localhost:5175")
                   .AllowAnyHeader()
                   .AllowAnyMethod();
        });
});

builder.Services.AddDbContext<ApplicationContext>(dbContextOptions => dbContextOptions.UseSqlite(connection));

//Injections Respository
builder.Services.AddScoped<IRepositoryMovie, RepositoryMovie>();
builder.Services.AddScoped<IShowService, ShowService>();
builder.Services.AddScoped<IDirectorServices, DirectorService>();

//Injection Service
builder.Services.AddScoped<IMovieServices, MovieServices>();
builder.Services.AddScoped<IRepositoryShow, RepositoryShow>();
builder.Services.AddScoped<IDirectorRepository, DirectorRepository>();


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.UseCors("AllowLocalhost");

app.Run();
