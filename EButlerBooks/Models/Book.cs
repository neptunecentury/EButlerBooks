using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EButlerBooks.Models
{
    public class Book
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string FullDescription { get; set; }
        public string ImageUrl { get; set; }
        public string ThumbImageUrl { get; set; }
        public string Url { get; set; }
        public bool ComingSoon { get; set; }
        public IList<BookAuthors> BookAuthors { get; set; }
        public IList<BookGenres> BookGenres { get; set; }
    }
}
