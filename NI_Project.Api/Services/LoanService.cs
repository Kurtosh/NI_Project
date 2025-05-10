using NI_Project.Api.Interfaces;
using NI_Project.Shared;

namespace NI_Project.Api.Services
{
    public class LoanService : ILoanService
    {
        private readonly List<Loan> _loans;
        public void Add(Loan loan)
        {
            _loans.Add(loan);
        }

        public Loan Get(string readerId, string bookId)
        {
            return _loans.Find(x => x.ReaderId == readerId && x.BookId == bookId);
        }

        public List<Loan> GetAll()
        {
            return _loans;
        }
    }
}
