using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NI_Project.Shared
{
    internal class Loan
    {
        [Required]
        public string ReaderId { get; set; }
        [Required]
        public string BookId { get; set; }
        [Required]
        public DateTime LoanDate { get; set; }
        [Required]
        public DateTime ReturnDeadline { get; set; }
    }
}
