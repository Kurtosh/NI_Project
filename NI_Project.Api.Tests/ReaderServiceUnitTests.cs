using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NI_Project.Api.Services;
using NI_Project.Shared;

namespace NI_Project.Api.Tests
{
    public class ReaderServiceUnitTests
    {
        [Fact]
        public void ValidReader_AddReader_AddsReader()
        {
            var service = new ReaderService();
            var reader = new Reader
            {
                Id = "r1",
                Name = "John Doe",
                Address = "123 Main St",
                BirthDate = new DateOnly(1990, 1, 1)
            };

            service.Add(reader);
            var all = service.GetAll();

            Assert.Single(all);
            Assert.Equal("John Doe", all[0].Name);
        }

        [Fact]
        public void InvalidReader_ShouldThrowArgumentNullException_ThrowsArgumentNullException()
        {
            var service = new ReaderService();
            Assert.Throws<ArgumentNullException>(() => service.Add(null));
        }

        [Fact]
        public void AlreadyExistingReader_ShouldThrowArgumentException_ThrowsArgumentException()
        {
            var service = new ReaderService();
            var reader = new Reader { Id = "r1", Name = "John" };
            service.Add(reader);

            var duplicate = new Reader { Id = "r1", Name = "Jane" };
            Assert.Throws<ArgumentException>(() => service.Add(duplicate));
        }

        [Fact]
        public void ExistingReader_ShouldRemoveReader_RemovesReader()
        {
            var service = new ReaderService();
            var reader = new Reader { Id = "r2", Name = "To Delete" };
            service.Add(reader);

            service.Delete("r2");

            Assert.Empty(service.GetAll());
        }

        [Theory]
        [InlineData(null)]
        [InlineData("")]
        public void NullOrEmptyId_ShouldThrowArgumentNullException_ThrowsArgumentNullException(string id)
        {
            var service = new ReaderService();
            Assert.Throws<ArgumentNullException>(() => service.Delete(id));
        }

        [Fact]
        public void NotExistingReader_ShouldThrowKeyNotFoundException_ThrowsKeyNotFoundException()
        {
            var service = new ReaderService();
            Assert.Throws<KeyNotFoundException>(() => service.Delete("notfound"));
        }

        [Fact]
        public void ValidReader_ShouldReturnCorrectReader_ReturnsCorrectReader()
        {
            var service = new ReaderService();
            var reader = new Reader { Id = "r3", Name = "Find Me" };
            service.Add(reader);

            var result = service.Get("r3");

            Assert.NotNull(result);
            Assert.Equal("Find Me", result.Name);
        }

        [Theory]
        [InlineData(null)]
        [InlineData("")]
        public void NullOrEmptyIdGet_ShouldThrowArgumentNullException_ThrowsArgumentNullException(string id)
        {
            var service = new ReaderService();
            Assert.Throws<ArgumentNullException>(() => service.Get(id));
        }

        [Fact]
        public void NotExistingReaderGet_ShouldThrowKeyNotFoundException_ThrowsKeyNotFoundException()
        {
            var service = new ReaderService();
            Assert.Throws<KeyNotFoundException>(() => service.Get("missing"));
        }

        [Fact]
        public void ValidReader_ShouldModifyReader_ModifiesReader()
        {
            var service = new ReaderService();
            var original = new Reader
            {
                Id = "r4",
                Name = "Old Name",
                Address = "Old Address",
                BirthDate = new DateOnly(1980, 1, 1)
            };
            service.Add(original);

            var updated = new Reader
            {
                Id = "r4",
                Name = "New Name",
                Address = "New Address",
                BirthDate = new DateOnly(1995, 5, 5)
            };
            service.Update(updated);

            var result = service.Get("r4");

            Assert.Equal("New Name", result.Name);
            Assert.Equal("New Address", result.Address);
            Assert.Equal(new DateOnly(1995, 5, 5), result.BirthDate);
        }

        [Fact]
        public void InvalidReaderUpdate_ShouldThrowArgumentNullException_ThrowsArgumentNullException()
        {
            var service = new ReaderService();
            Assert.Throws<ArgumentNullException>(() => service.Update(null));
        }

        [Fact]
        public void NotExistingReaderUpdate_ShouldThrowKeyNotFoundException_ThrowsKeyNotFoundException()
        {
            var service = new ReaderService();
            var reader = new Reader { Id = "notexist", Name = "Ghost" };
            Assert.Throws<KeyNotFoundException>(() => service.Update(reader));
        }
    }
}
