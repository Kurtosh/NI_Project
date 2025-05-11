using System;
using NI_Project.Shared;

namespace NI_Project.UI.Services
{
    public interface IBooksService
    {
        Task<List<Book>> GetBooksAsync();

        Task<Book> GetBookAsync(string id);

        Task AddBookAsync(Book book);

        Task UpdateBookAsync(Book book);

        Task DeletePersonAsync(string id);
    }
}
