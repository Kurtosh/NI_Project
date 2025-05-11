using System.Net.Http.Json;
using NI_Project.Shared;

namespace NI_Project.UI.Services
{
    public class ReadersService : IReadersService
    {
        private readonly HttpClient _httpClient;

        public ReadersService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }
        public async Task AddReaderAsync(Reader reader)
        {
            await _httpClient.PostAsJsonAsync("readers", reader);
        }

        public async Task DeleteReaderAsync(string id)
        {
            await _httpClient.DeleteAsync($"readers/{id}");
        }

        public async Task<Reader> GetReaderAsync(string id)
        {
            return await _httpClient.GetFromJsonAsync<Reader>($"readers/{id}");
        }

        public async Task<List<Reader>> GetReadersAsync()
        {
            return await _httpClient.GetFromJsonAsync<List<Reader>>("readers");
        }

        public async Task UpdateReaderAsync(string id, Reader reader)
        {
            await _httpClient.PutAsJsonAsync($"readers/{id}", reader);
        }
    }
}
