using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EButlerBooks.Models
{
    public class DbEntities : DbContext
    {
        public DbEntities() : base()
        {

        }

        public DbEntities(DbContextOptions options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Configure many to many relationships
            // Authors and books
            modelBuilder.Entity<BookAuthors>().HasKey(sc => new { sc.AuthorId, sc.BookId });
            // Book genres
            modelBuilder.Entity<BookGenres>().HasKey(sc => new { sc.GenreId, sc.BookId });
                        
            // Initialize the DB with data
            // Genres
            modelBuilder.Entity<Genre>().HasData(new Genre { Id = 1, Name = "Fantasy" });
            modelBuilder.Entity<Genre>().HasData(new Genre { Id = 2, Name = "Science Fiction" });

            // Authors
            modelBuilder.Entity<Author>().HasData(new Author { Id = 1, FirstName = "Eric", LastName = "Butler" });

            // Dark World
            modelBuilder.Entity<Book>().HasData(new Book { Id = 1, Title = "Dark World", Description = "A book about a dark world.", FullDescription = "In a world where darkness is everywhere, one woman fights to bring it light." });

            modelBuilder.Entity<BookAuthors>().HasData(new BookAuthors { AuthorId = 1, BookId = 1 });
            modelBuilder.Entity<BookGenres>().HasData(new BookGenres { BookId = 1, GenreId = 1 });
            modelBuilder.Entity<BookGenres>().HasData(new BookGenres { BookId = 1, GenreId = 2 });

            // Angie Gordon
            modelBuilder.Entity<Book>().HasData(new Book { Id = 2, Title = "Angie Gordon", Description = "Robots. A.I.", FullDescription = "Angie Gordon get trapped in her worst nightmare" });

            modelBuilder.Entity<BookAuthors>().HasData(new BookAuthors { AuthorId = 1, BookId = 2 });
            modelBuilder.Entity<BookGenres>().HasData(new BookGenres { BookId = 2, GenreId = 2 });

            // Fantasy
            modelBuilder.Entity<Book>().HasData(new Book { Id = 3, Title = "Fantasy", Description = "Boy kidnaps girl", FullDescription = "Boy kidnaps girl and takes her to a fantasy realm to help him find his long-lost sister." });

            modelBuilder.Entity<BookAuthors>().HasData(new BookAuthors { AuthorId = 1, BookId = 3 });
            modelBuilder.Entity<BookGenres>().HasData(new BookGenres { BookId = 3, GenreId = 1 });

            // App settings
            modelBuilder.Entity<AppSettings>().HasData(new AppSettings { Id = 1, FeaturedBookId = 1 });

            base.OnModelCreating(modelBuilder);
        }


        public DbSet<Author> Authors { get; set; }
        public DbSet<Book> Books { get; set; }
        public DbSet<Genre> Genres { get; set; }
        public DbSet<AppSettings> AppSettings { get; set; }
    }
}
