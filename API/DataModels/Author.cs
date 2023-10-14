using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EButlerBooks.DataModels
{
    public class Author
    {
        public int Id { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string FullName{ get { return $"{FirstName} {LastName}"; } }

        public virtual IList<BookAuthors> BookAuthors { get; set; } = null!;
    }
}
