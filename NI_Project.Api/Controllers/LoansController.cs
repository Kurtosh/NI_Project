using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
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

            var readerExists = await _loanDataContext.Readers.AnyAsync(r => r.Id == loan.ReaderId);
            if (!readerExists)
            {
                return BadRequest($"Reader with ID '{loan.ReaderId}' does not exist.");
            }

            var bookExists = await _loanDataContext.Books.AnyAsync(b => b.Id == loan.BookId);
            if (!bookExists)
            {
                return BadRequest($"Book with ID '{loan.BookId}' does not exist.");
            }

            _loanDataContext.Loans.Add(loan);

            await _loanDataContext.SaveChangesAsync();

            return Ok();
        }

        [HttpDelete("{bookId}")]
        public async Task<IActionResult> Delete(string bookId)
        {
            var existingLoan = await _loanDataContext.Loans.FindAsync(bookId);

            if (existingLoan is null)
            {
                return NotFound();
            }

            _loanDataContext.Loans.Remove(existingLoan);
            await _loanDataContext.SaveChangesAsync();

            return Ok();
        }

        [HttpGet]
        public async Task<ActionResult<List<Loan>>> GetAll()
        {
            var loans = await _loanDataContext.Loans.ToListAsync();
            return Ok(loans);
        }
    }
}
