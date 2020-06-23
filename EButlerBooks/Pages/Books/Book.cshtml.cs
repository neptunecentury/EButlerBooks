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
    public class BookModel : PageModel
    {
        private readonly ILogger<BookModel> _logger;
        private readonly DbEntities _db;

        #region Public properties
        public Book Book { get; set; }
        #endregion

        public BookModel(ILogger<BookModel> logger, DbEntities db)
        {
            _logger = logger;
            _db = db;
        }

        public async Task<IActionResult> OnGet(string url)
        {

            // Get all the books
            Book = await (from s in _db.Books.Include(b => b.BookAuthors).ThenInclude(ba => ba.Author)
                          where s.Url == url
                          select s).FirstOrDefaultAsync();

            if (Book == null)
            {
                return NotFound();
            }
            
            return Page();
        }
    }
}