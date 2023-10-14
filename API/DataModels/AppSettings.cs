using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace EButlerBooks.DataModels
{
    public class AppSettings
    {
        public int? FeaturedBookId { get; set; }
        [ForeignKey("FeaturedBookId")]
        public Book? FeaturedBook { get; set; }

        public string? BannerImageUrl { get; set; }
    }
}
