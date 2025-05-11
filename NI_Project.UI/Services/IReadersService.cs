using NI_Project.Shared;

namespace NI_Project.UI.Services
{
    public interface IReadersService
    {
        Task<List<Reader>> GetReadersAsync();

        Task<Reader> GetReaderAsync(string id);

        Task AddReaderAsync(Reader reader);

        Task UpdateReaderAsync(string id, Reader reader);

        Task DeleteReaderAsync(string id);
    }
}
