using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EButlerBooks.Models
{
    public class BookAuthors
    {
        public int AuthorId { get; set; }
        public Author Author { get; set; }

        public int BookId { get; set; }
        public Book Book { get; set; }
    }
}
