using NI_Project.Shared;

namespace NI_Project.UI.Services
{
    public interface ILoansService
    {
        Task<List<Loan>> GetLoansAsync();

        Task<Book> GetLoanAsync(string rId, string bId);

        Task AddLoanAsync(Loan loan);
    }
}
