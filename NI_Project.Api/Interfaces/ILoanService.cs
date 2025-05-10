using NI_Project.Shared;

namespace NI_Project.Api.Interfaces
{
    public interface ILoanService
    {
        void Add(Loan loan);

        List<Loan> GetAll();

        Loan Get(string readerId, string bookId);
    }
}
