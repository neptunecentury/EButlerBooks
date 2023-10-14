using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EButlerBooks.DataModels
{
    public class BookAuthors
    {
        public int AuthorId { get; set; }
        public virtual Author Author { get; set; } = null!;

        public int BookId { get; set; }
        public virtual Book Book { get; set; } = null!;
    }
}
