using EButlerBooks.DataModels;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);
var corsPolicyName = "CorsProductionWithOrigins";


// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Get connection string
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
// Create a DI service for DbEntities to be injected
builder.Services.AddDbContext<DbEntities>(options => options.UseSqlServer(connectionString));

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
    return db.Books;
})
.WithName("GetBooks")
.WithOpenApi();

app.Run();
