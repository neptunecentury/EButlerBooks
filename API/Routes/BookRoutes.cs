using Microsoft.EntityFrameworkCore;
using EButlerBooks.DataModels;
using EButlerBooks.DTOs;

namespace API.Routes
{
    public static class BookRoutes
    {

        /// <summary>
        /// Maps the routes used for /books
        /// </summary>
        /// <param name="app"></param>
        public static void MapBookRoutes(this WebApplication app)
        {

            // Maps /books
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
                        ImageUrl = b.ImageUrl,
                        ThumbImageUrl = b.ThumbImageUrl,
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
                var b = books.ToArray();
                return b;

            })
            .WithName("GetBooks")
            .WithOpenApi();

        }
    }
}
