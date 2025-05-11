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
            var book = new Book
            {
                Id = "b1",
                Title = "Test Book",
                Author = "Author",
                Publisher = "Publisher",
                YearOfPublish = 2020
            };

            service.Add(book);
            var result = service.Get("b1");

            Assert.Equal("Test Book", result.Title);
        }

        [Fact]
        public void InvalidBook_ShouldThrowArgumentNullException_ThrowsArgumentNullException()
        {
            var service = new BookService();
            Assert.Throws<ArgumentNullException>(() => service.Add(null));
        }

        [Fact]
        public void AlreadyExistingBook_ShouldThrowArgumentException_ThrowsArgumentException()
        {
            var service = new BookService();
            var book = new Book { Id = "b2", Title = "Dup" };
            service.Add(book);

            var duplicate = new Book { Id = "b2", Title = "Dup2" };
            Assert.Throws<ArgumentException>(() => service.Add(duplicate));
        }

        [Theory]
        [InlineData(null)]
        [InlineData("")]
        public void NullOrEmptyId_ShouldThrowArgumentNullException_ThrowsArgumentNullException(string id)
        {
            var service = new BookService();
            Assert.Throws<ArgumentNullException>(() => service.Delete(id));
        }

        [Fact]
        public void NotExistingBook_ShouldThrowKeyNotFoundException_ThrowsKeyNotFoundException()
        {
            var service = new BookService();
            Assert.Throws<KeyNotFoundException>(() => service.Delete("missing"));
        }

        [Fact]
        public void ExistingBook_ShouldRemoveBook_RemovesBook()
        {
            var service = new BookService();
            var book = new Book { Id = "b3", Title = "To Remove" };
            service.Add(book);

            service.Delete("b3");

            Assert.Throws<KeyNotFoundException>(() => service.Get("b3"));
        }

        [Fact]
        public void ValidBook_ShouldReturnCorrectBook_ReturnsCorrectBook()
        {
            var service = new BookService();
            var book = new Book { Id = "b5", Title = "Find Me" };
            service.Add(book);

            var result = service.Get("b5");

            Assert.NotNull(result);
            Assert.Equal("Find Me", result.Title);
        }

        [Theory]
        [InlineData(null)]
        [InlineData("")]
        public void NullOrEmptyIdGet_ShouldThrowArgumentNullException_ThrowsArgumentNullException(string id)
        {
            var service = new BookService();
            Assert.Throws<ArgumentNullException>(() => service.Get(id));
        }

        [Fact]
        public void NotExistingReaderGet_ShouldThrowKeyNotFoundException_ThrowsKeyNotFoundException()
        {
            var service = new BookService();
            Assert.Throws<KeyNotFoundException>(() => service.Get("missing"));
        }

        [Fact]
        public void ValidBook_ShouldModifyBook_ModifiesBook()
        {
            var service = new BookService();
            var original = new Book
            {
                Id = "b4",
                Title = "Old Title",
                Author = "Old Author",
                Publisher = "Old Publisher",
                YearOfPublish = 2000
            };
            service.Add(original);

            var updated = new Book
            {
                Id = "b4",
                Title = "New Title",
                Author = "New Author",
                Publisher = "New Publisher",
                YearOfPublish = 2023
            };

            service.Update(updated);
            var result = service.Get("b4");

            Assert.Equal("New Title", result.Title);
            Assert.Equal("New Author", result.Author);
            Assert.Equal("New Publisher", result.Publisher);
            Assert.Equal(2023, result.YearOfPublish);
        }

        [Fact]
        public void InvalidBookUpdate_ShouldThrowArgumentNullException_ThrowsArgumentNullException()
        {
            var service = new BookService();
            Assert.Throws<ArgumentNullException>(() => service.Update(null));
        }

        [Fact]
        public void NotExistingBookUpdate_ShouldThrowKeyNotFoundException_ThrowsKeyNotFoundException()
        {
            var service = new BookService();
            var book = new Book { Id = "nonexist", Title = "Ghost Book" };
            Assert.Throws<KeyNotFoundException>(() => service.Update(book));
        }
    }
}
