using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace TVLibraryAPI.Models
{
    /// <summary>
    /// Show Model class
    /// </summary>
    public class Show
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Title { get; set; }
        [Required]
        public string Summary { get; set; }
        [Required]
        public int PlatformId { get; set; }
        [Required]
        public string Schedule { get; set; }

        public Platform Platform { get; set; }
    }
}
