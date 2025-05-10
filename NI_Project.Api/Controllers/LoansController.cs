using Microsoft.AspNetCore.Mvc;
using NI_Project.Shared;

namespace NI_Project.Api.Controllers
{
    [ApiController]
    [Route("loans")]
    public class LoansController : ControllerBase
    {
        private readonly BookDataContext _loanDataContext;

        public LoansController(BookDataContext loanDataContext)
        {
            _loanDataContext = loanDataContext;
        }

        [HttpPost]
        public async Task<IActionResult> Add([FromBody] Loan loan)
        {
            var existingLoanBI = await _loanDataContext.Loans.FindAsync(loan.BookId);

            if (existingLoanBI is not null)
            {
                return Conflict();
            }

            _loanDataContext.Loans.Add(loan);
            await _loanDataContext.SaveChangesAsync();

            return Ok();
        }
    }
}
