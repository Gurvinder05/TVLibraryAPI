﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace TVLibraryAPI.Models
{
    /// <summary>
    /// Platform Model class
    /// </summary>
    public class Platform
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }

        public IList<Show> shows { get; set; }
    }
}
