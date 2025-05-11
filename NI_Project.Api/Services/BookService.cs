using System;
using NI_Project.Api.Interfaces;
using NI_Project.Shared;

namespace NI_Project.Api.Services
{
    public class BookService : IBookService
    {
        private readonly List<Book> _books = new List<Book>();
        public void Add(Book book)
        {
            if (book == null)
            {
                throw new ArgumentNullException(nameof(book));
            }
                
            if (_books.Any(b => b.Id == book.Id))
            {
                throw new ArgumentException($"Book with ID '{book.Id}' already exists.");
            }

            _books.Add(book);
        }

        public void Delete(string id)
        {
            if (string.IsNullOrWhiteSpace(id))
            {
                throw new ArgumentNullException(nameof(id));
            }

            var removed = _books.RemoveAll(x => x.Id == id);
            if (removed == 0)
            {
                throw new KeyNotFoundException($"Book with ID '{id}' not found.");
            }
        }

        public Book Get(string id)
        {
            if (string.IsNullOrWhiteSpace(id))
            {
                throw new ArgumentNullException(nameof(id));
            }

            var book = _books.Find(x => x.Id == id);
            if (book == null)
            {
                throw new KeyNotFoundException($"Book with ID '{id}' not found.");
            }

            return book;
        }

        public List<Book> GetAll()
        {
            return _books;
        }

        public void Update(Book book)
        {
            if (book == null)
            {
                throw new ArgumentNullException(nameof(book));
            }

            var oldBook = Get(book.Id);

            oldBook.Title = book.Title;
            oldBook.Author = book.Author;
            oldBook.Publisher = book.Publisher;
            oldBook.YearOfPublish = book.YearOfPublish;
        }
    }
}
