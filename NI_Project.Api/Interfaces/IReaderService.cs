using NI_Project.Shared;

namespace NI_Project.Api.Interfaces
{
    public interface IReaderService
    {
        void Add(Reader reader);

        void Delete(string id);

        List<Reader> GetAll();

        Reader Get(string id);

        void Update(Reader reader);
    }
}
