using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EButlerBooks.DataModels
{
    public class Genre
    {
        public int Id { get; set; }
        public string? Name { get; set; }

        public IList<BookGenres> BookGenres { get; set; } = null!;
    }
}
