using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EButlerBooks.Models
{
    public class BookGenres
    {
        public int BookId { get; set; }
        public Book Book { get; set; }

        public int GenreId { get; set; }
        public Genre Genre { get; set; }
    }
}
