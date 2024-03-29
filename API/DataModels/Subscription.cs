﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace EButlerBooks.DataModels
{
    public class Subscription
    {
        public int Id { get; set; }

        [Required]
        [EmailAddress]
        public required string Email { get; set; }
    }
}
