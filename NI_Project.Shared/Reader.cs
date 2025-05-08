using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NI_Project.Shared
{
    public class Reader
    {
        [Required]
        public string Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Address { get; set; }
        [Required]
        [Range(typeof(DateOnly), "1900-01-01", "2025-01-01")]
        public DateOnly? BirthDate { get; set; }
    }
}
