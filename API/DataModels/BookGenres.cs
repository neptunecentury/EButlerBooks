using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EButlerBooks.DataModels
{
    public class BookGenres
    {
        public int BookId { get; set; }
        public virtual Book Book { get; set; } = null!;

        public int GenreId { get; set; }
        public virtual Genre Genre { get; set; } = null!;
    }
}
