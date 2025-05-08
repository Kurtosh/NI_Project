using NI_Project.Shared;
namespace NI_Project.Api.Interfaces
{
    public interface IBookService
    {
        void Add(Book book);

        void Delete(string id);

        List<Book> GetAll();

        Book Get(string id);

        void Update(Book book);
    }
}
