using System.Net.Http.Json;
using NI_Project.Shared;

namespace NI_Project.UI.Services
{
    public class LoansService : ILoansService
    {
        private readonly HttpClient _httpClient;

        public LoansService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }
        public async Task AddLoanAsync(Loan loan)
        {
            await _httpClient.PostAsJsonAsync("loans", loan);
        }

        public async Task<Book> GetLoanAsync(string rId, string bId)
        {
            return await _httpClient.GetFromJsonAsync<Book>($"loans/{rId}");
        }

        public async Task<List<Loan>> GetLoansAsync()
        {
            return await _httpClient.GetFromJsonAsync<List<Loan>>("loans");
        }
    }
}
