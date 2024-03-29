﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EButlerBooks.DTOs
{
    public class BookResponse
    {
        public int Id { get; set; }
        public string? Title { get; set; }
        public string? Description { get; set; }
        public string? FullDescription { get; set; }
        public string? ImageUrl { get; set; }
        public string? ThumbImageUrl { get; set; }
        public string? Url { get; set; }
        public bool ComingSoon { get; set; }
        public bool IsFeatured { get; set; }

        public AuthorResponse[] Authors { get; set; } = null!;
        public GenreResponse[] Genres { get; set; } = null!;
    }
}
