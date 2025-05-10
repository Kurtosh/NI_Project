using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NI_Project.Shared
{
    public class Loan : IValidatableObject
    {
        [Required]
        public string ReaderId { get; set; }
        [Key]
        public string BookId { get; set; }
        [Required]
        public DateOnly LoanDate { get; set; }
        [Required]
        public DateOnly ReturnDeadline { get; set; }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            var today = DateOnly.FromDateTime(DateTime.Today);

            if (LoanDate < today)
            {
                yield return new ValidationResult(
                    "A kölcsönzés ideje nem lehet korábbi a mai napnál.",
                    new[] { nameof(LoanDate) });
            }

            if (ReturnDeadline <= LoanDate)
            {
                yield return new ValidationResult(
                    "A visszahozási határidőnek későbbinek kell lennie, mint a kölcsönzés ideje.",
                    new[] { nameof(ReturnDeadline) });
            }
        }
    }

}
