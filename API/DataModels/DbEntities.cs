using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EButlerBooks.DataModels
{
    public class DbEntities : DbContext
    {

        public DbSet<Author> Authors => Set<Author>();
        public DbSet<Book> Books => Set<Book>();
        public DbSet<Genre> Genres => Set<Genre>();
        public DbSet<Subscription> Subscriptions => Set<Subscription>();
        public DbSet<AppSettings> AppSettings => Set<AppSettings>();

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
            //modelBuilder.Entity<Author>().HasData(new Author { Id = 2, FirstName = "Jared", LastName = "Lassetter" });

            // Dark World
            modelBuilder.Entity<Book>().HasData(new Book {
                Id = 1,
                Title = "Dark World",
                Description = "A book about a dark world.",
                FullDescription = "In a world where darkness is everywhere, one woman fights to bring it light.",
                ImageUrl = "dark-world-cover.png",
                ThumbImageUrl = "dark-world-cover-thumb.png"
            });

            modelBuilder.Entity<BookAuthors>().HasData(new BookAuthors { AuthorId = 1, BookId = 1 });
            //modelBuilder.Entity<BookAuthors>().HasData(new BookAuthors { AuthorId = 2, BookId = 1 });
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

            // Ashes of the Earthborne
            modelBuilder.Entity<Book>().HasData(new Book { Id = 4, Title = "Ashes of the Earthborne", Description = "A young princess fights to reclaim her kingdom", FullDescription = "A young princess fights to reclaim her throne after a coup led to the death of her mother and father. But how far will she go get take back her kingdom?" });

            modelBuilder.Entity<BookAuthors>().HasData(new BookAuthors { AuthorId = 1, BookId = 4 });
            modelBuilder.Entity<BookGenres>().HasData(new BookGenres { BookId = 4, GenreId = 1 });

            // App settings
            modelBuilder.Entity<AppSettings>().HasNoKey();

            base.OnModelCreating(modelBuilder);
        }

    }
}
