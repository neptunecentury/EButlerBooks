using EButlerBooks.DataModels;
using EButlerBooks.DTOs;
using Microsoft.AspNetCore.Http.Json;
using Microsoft.EntityFrameworkCore;
using System.Text.Json.Serialization;

var builder = WebApplication.CreateBuilder(args);
var corsPolicyName = "CorsProductionWithOrigins";


// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Set the JSON serializer options.
builder.Services.Configure<JsonOptions>(options =>
{
    options.SerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles;
});

// Get connection string
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
// Create a DI service for DbEntities to be injected
builder.Services.AddDbContext<DbEntities>(options =>
{
    options.UseSqlServer(connectionString);
});

builder.Services.AddCors(options =>
{
#if DEBUG
    // Development policy
    options.AddPolicy(name: corsPolicyName,
                      policy =>
                      {
                          policy.WithOrigins("http://localhost:8080", "http://localhost:3000")
                          .AllowAnyHeader()
                          .AllowAnyMethod();
                      });
#else
    // Production policy
    options.AddPolicy(name: corsPolicyName,
                      policy =>
                      {
                          policy.WithOrigins("https://ebutlerbooks.com", "https://www.ebutlerbooks.com")
                          .AllowAnyHeader()
                          .AllowAnyMethod();
                      });
#endif
});


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseCors(corsPolicyName);


app.MapGet("/books", (DbEntities db) =>
{
    var books = db.Books
        .Include((b) => b.BookAuthors).ThenInclude(ba => ba.Author)
        .Include((b) => b.BookGenres).ThenInclude(bg => bg.Genre)
        .Select((b) => new BookResponse()
        {
            Id = b.Id,
            Title = b.Title,
            Description = b.Description,
            Authors = b.BookAuthors.Select(ba => new AuthorResponse()
            {
                Id = ba.AuthorId,
                FirstName = ba.Author.FirstName,
                LastName = ba.Author.LastName
            }).ToArray(),
            Genres = b.BookGenres.Select(bg => new GenreResponse()
            {
                Id = bg.GenreId,
                Name = bg.Genre.Name
            }).ToArray()
        });

    return books.ToArray();

})
.WithName("GetBooks")
.WithOpenApi();

app.Run();
