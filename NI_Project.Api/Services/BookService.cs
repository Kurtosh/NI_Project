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
            _books.Add(book);
        }

        public void Delete(string id)
        {
            _books.RemoveAll(x => x.Id == id);
        }

        public Book Get(string id)
        {
            return _books.Find(x => x.Id == id);
        }

        public List<Book> GetAll()
        {
            return _books;
        }

        public void Update(Book book)
        {
            var oldBook = Get(book.Id);

            oldBook.Title = book.Title;
            oldBook.Author = book.Author;
            oldBook.Publisher = book.Publisher;
            oldBook.YearOfPublish = book.YearOfPublish;
        }
    }
}
