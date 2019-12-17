using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EButlerBooks.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace EButlerBooks.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;
        private readonly DbEntities _db;
        private Book _featuredBook;

        public IndexModel(ILogger<IndexModel> logger, DbEntities db)
        {
            _logger = logger;
            _db = db;
        }

        public void OnGet()
        {
            // Get the featured book from the app's settings
            var appSettings = (from s in _db.AppSettings.Include(a => a.FeaturedBook)
                               where s.Id == 1
                               select s).FirstOrDefault();
            //_featuredBook = appSettings?.FeaturedBook;
        }
    }
}
