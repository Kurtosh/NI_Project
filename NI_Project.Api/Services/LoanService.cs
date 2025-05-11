using NI_Project.Api.Interfaces;
using NI_Project.Shared;

namespace NI_Project.Api.Services
{
    public class LoanService : ILoanService
    {
        private readonly List<Loan> _loans = new List<Loan>();
        public void Add(Loan loan)
        {
            if (loan == null)
            {
                throw new ArgumentNullException(nameof(loan));
            }

            if (_loans.Any(l => l.ReaderId == loan.ReaderId && l.BookId == loan.BookId))
            {
                throw new ArgumentException($"Loan already exists for reader '{loan.ReaderId}' and book '{loan.BookId}'.");
            }                

            _loans.Add(loan);
        }

        public Loan Get(string readerId, string bookId)
        {
            if (string.IsNullOrWhiteSpace(readerId))
            {
                throw new ArgumentNullException(nameof(readerId));
            }
            if (string.IsNullOrWhiteSpace(bookId))
            {
                throw new ArgumentNullException(nameof(bookId));
            }

            var loan = _loans.Find(x => x.ReaderId == readerId && x.BookId == bookId);
            if (loan == null)
            {
                throw new KeyNotFoundException($"Loan not found for reader '{readerId}' and book '{bookId}'.");
            }

            return loan;
        }

        public List<Loan> GetAll()
        {
            return _loans;
        }
    }
}
