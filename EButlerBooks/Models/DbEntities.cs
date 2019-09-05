using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EButlerBooks.Models
{
    public class DbEntities : DbContext
    {

        public DbEntities(DbContextOptions options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Initialize the DB with data
            modelBuilder.Entity<Author>().HasData(new Author { Id = 1, FirstName = "Eric", LastName = "Butler" });
            modelBuilder.Entity<Book>().HasData(new Book { Id = 1, Title = "Dark World",  Description= "Butler" });

            base.OnModelCreating(modelBuilder);
        }


        DbSet<Author> Authors { get; set; }
        DbSet<Book> Books { get; set; }
    }
}
