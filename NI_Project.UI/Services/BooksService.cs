using System.Net.Http.Json;
using System;
using NI_Project.Shared;

namespace NI_Project.UI.Services
{
    public class BooksService : IBooksService
    {
        private readonly HttpClient _httpClient;

        public BooksService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }
        public async Task AddBookAsync(Book book)
        {
            await _httpClient.PostAsJsonAsync("books", book);
        }

        public async Task DeleteBookAsync(string id)
        {
            await _httpClient.DeleteAsync($"books/{id}");
        }

        public async Task<Book> GetBookAsync(string id)
        {
            return await _httpClient.GetFromJsonAsync<Book>($"books/{id}");
        }

        public async Task<List<Book>> GetBooksAsync()
        {
            return await _httpClient.GetFromJsonAsync<List<Book>>("books");
        }

        public async Task UpdateBookAsync(string id, Book book)
        {
            await _httpClient.PutAsJsonAsync($"books/{id}", book);
        }
    }
}
