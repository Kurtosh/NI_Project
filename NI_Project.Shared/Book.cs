using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NI_Project.Shared
{
    internal class Book
    {
        [Required]
        public string Id { get; set; }
        [Required]
        public string Title { get; set; }
        [Required]
        public string Author { get; set; }
        [Required]
        public string Publisher { get; set; }
        [Required]
        [Range(0, 2025)]
        public int YearOfPublish { get; set; }
    }
}
