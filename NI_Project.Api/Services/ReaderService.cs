using NI_Project.Api.Interfaces;
using NI_Project.Shared;

namespace NI_Project.Api.Services
{
    public class ReaderService : IReaderService
    {
        private readonly List<Reader> _readers = new List<Reader>();
        public void Add(Reader reader)
        {
            if (reader == null)
            {
                throw new ArgumentNullException(nameof(reader));
            }

            if (_readers.Any(r => r.Id == reader.Id))
            {
                throw new ArgumentException($"Reader with ID '{reader.Id}' already exists.");
            }                

            _readers.Add(reader);
        }

        public void Delete(string id)
        {
            if (string.IsNullOrWhiteSpace(id))
            {
                throw new ArgumentNullException(nameof(id));
            }

            var removed = _readers.RemoveAll(x => x.Id == id);
            if (removed == 0)
            {
                throw new KeyNotFoundException($"Reader with ID '{id}' not found.");
            }               
        }

        public Reader Get(string id)
        {
            if (string.IsNullOrWhiteSpace(id))
            {
                throw new ArgumentNullException(nameof(id));
            }

            var reader = _readers.Find(x => x.Id == id);
            if (reader == null)
            {
                throw new KeyNotFoundException($"Reader with ID '{id}' not found.");
            }

            return reader;
        }

        public List<Reader> GetAll()
        {
            return _readers;
        }

        public void Update(Reader reader)
        {
            if (reader == null)
            {
                throw new ArgumentNullException(nameof(reader));
            }

            var oldReader = Get(reader.Id);

            oldReader.Name = reader.Name;
            oldReader.Address = reader.Address;
            oldReader.BirthDate = reader.BirthDate;
        }
    }
}
