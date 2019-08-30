using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EButlerBooks.Models
{
    public class DbEntities : DbContext
    {
        //public DbEntities() : base()
        //{

        //}
        public DbEntities(DbContextOptions options) : base(options)
        {
           
        }

        DbSet<Book> Books { get; set; }
    }
}
