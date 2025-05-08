using NI_Project.Api.Interfaces;
using NI_Project.Shared;

namespace NI_Project.Api.Services
{
    public class ReaderService : IReaderService
    {
        private readonly List<Reader> _readers;
        public void Add(Reader reader)
        {
            _readers.Add(reader);
        }

        public void Delete(string id)
        {
            _readers.RemoveAll(x => x.Id == id);
        }

        public Reader Get(string id)
        {
            return _readers.Find(x => x.Id == id);
        }

        public List<Reader> GetAll()
        {
            return _readers;
        }

        public void Update(Reader reader)
        {
            var oldReader = Get(reader.Id);

            oldReader.Name = reader.Name;
            oldReader.Address = reader.Address;
            oldReader.BirthDate = reader.BirthDate;
        }
    }
}
