using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NI_Project.Api.Services;
using NI_Project.Shared;

namespace NI_Project.Api.Tests
{
    public class BookServiceUnitTests
    {
        [Fact]
        public void ValidBook_AddBook_AddsBook()
        {
            var service = new BookService();
            var book = new Book { Id = "1", Title = "Test", Author = "Author", Publisher = "Publisher", YearOfPublish = 2020 };

            service.Add(book);
            var result = service.GetAll();

            Assert.Equal("Test", result[0].Title);
        }

        [Fact]
        public void ExistingBook_ShouldRemoveBook_RemovesBook()
        {
            var service = new BookService();
            var book = new Book { Id = "1", Title = "To Be Deleted" };

            service.Add(book);
            service.Delete("1");

            Assert.Empty(service.GetAll());
        }

        [Fact]
        public void ValidBookId_ShouldReturnCorrectBook_ReturnsCorrectBook()
        {
            var service = new BookService();
            var book = new Book { Id = "2", Title = "Find Me" };

            service.Add(book);
            var result = service.Get("2");

            Assert.NotNull(result);
            Assert.Equal("Find Me", result.Title);
        }

        [Fact]
        public void InvalidBookId_ShouldReturnNull_ReturnsNulld()
        {
            var service = new BookService();
            var result = service.Get("nonexistent");

            Assert.Null(result);
        }

        [Fact]
        public void ValidBookId_ShouldUpdateOldBook_UpdatesOldBook()
        {
            var service = new BookService();
            var originalBook = new Book
            {
                Id = "3",
                Title = "Old Title",
                Author = "Old Author",
                Publisher = "Old Publisher",
                YearOfPublish = 1999
            };
            service.Add(originalBook);

            var updatedBook = new Book
            {
                Id = "3",
                Title = "New Title",
                Author = "New Author",
                Publisher = "New Publisher",
                YearOfPublish = 2022
            };
            service.Update(updatedBook);

            var result = service.Get("3");

            Assert.Equal("New Title", result.Title);
            Assert.Equal("New Author", result.Author);
            Assert.Equal("New Publisher", result.Publisher);
            Assert.Equal(2022, result.YearOfPublish);
        }
    }
}
