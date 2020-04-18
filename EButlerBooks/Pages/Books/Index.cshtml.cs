using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EButlerBooks.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace EButlerBooks.Pages.Books
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;
        private readonly DbEntities _db;

        #region Public properties
        public Book[] Books { get; set; }
        #endregion

        public IndexModel(ILogger<IndexModel> logger, DbEntities db)
        {
            _logger = logger;
            _db = db;
        }

        public void OnGet()
        {
            // Get all the books
            Books = (from s in _db.Books.Include(b => b.BookAuthors).ThenInclude(ba => ba.Author)
                     select s).ToArray();
        }
    }
}